using AgileHttp;
using Newtonsoft.Json;

namespace GitlabGroupForker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private List<dynamic> _gps = new List<dynamic>();
        private GitlabApis _gitlabApis = new GitlabApis();

        private void Form1_Load(object sender, EventArgs e)
        {
            var result = _gitlabApis.Login();
            if (result)
            {
                this.AddLog("login success !");
            }
            else
            {
                this.AddLog("login FAIL !");
            }
        }

        private void btnQueryFrom_Click(object sender, EventArgs e)
        {
            _gps = _gitlabApis.GetGroups();
            if (!ValidInput(this.txtFromId))
            {
                return;
            }

            var id = this.txtFromId.Text;
            var gp = _gps.FirstOrDefault(x => x.id.ToString() == id);
            if (gp != null)
            {
                var str = _gitlabApis.GetGroup(id);
                this.txtLogs.Text = str;
            }
            else
            {
                MessageBox.Show("can not find project " + id);
            }
        }

        private bool ValidInput(TextBox tbx)
        {
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                MessageBox.Show("project id can not empty");
                return false;
            }
            var gp = _gps.FirstOrDefault(x => x.id == tbx.Text);
            if (gp == null)
            {
                MessageBox.Show("can not find project " + tbx.Text);
                return false;
            }

            return true;
        }

        private void btnQueryTo_Click(object sender, EventArgs e)
        {
            _gps = _gitlabApis.GetGroups();
            if (!ValidInput(this.txtToId))
            {
                return;
            }

            var id = this.txtToId.Text;
            var gp = _gps.FirstOrDefault(x => x.id.ToString() == id);
            if (gp != null)
            {
                var str = _gitlabApis.GetGroup(id);
                this.txtLogs.Text = str;
            }
            else
            {
                MessageBox.Show("can not find project " + id);
            }
        }

        private void btnFork_Click_1(object sender, EventArgs e)
        {
            _gps = _gitlabApis.GetGroups();
            if (!ValidInput(this.txtFromId))
            {
                return;
            }
            if (!ValidInput(this.txtToId))
            {
                return;
            }

            this.btnFork.Enabled = false;
            Task.Run(() =>
            {
                try
                {
                    this.ForkGroup(this.txtFromId.Text, this.txtToId.Text);
                    this.AddLog($"success fork group {this.txtFromId.Text} to {this.txtToId.Text} !!!");
                }
                catch (Exception e)
                {
                    this.AddLog($"fork group {this.txtFromId.Text} to {this.txtToId.Text} ERROR");
                    this.AddLog(e.Message);
                    this.AddLog(e.StackTrace ?? "");
                }
                finally
                {
                    this.EnabledButton();
                }
            }).ConfigureAwait(false)
            ;
        }

        private void EnabledButton()
        {
            this.btnFork.Invoke(() =>
            {
                this.btnFork.Enabled = true;
            });
        }

        private void ForkGroup(string fromId, string toGp)
        {
            var sbgs = _gitlabApis.GetSubGroups(fromId);
            if (sbgs != null && sbgs.Count > 0)
            {
                foreach (var sbg in sbgs)
                {
                    string path = sbg.path.ToString();
                    string name = sbg.name.ToString();
                    string id = sbg.id.ToString();
                    var newGpid = _gitlabApis.CreateSGp(path, name, toGp);
                    string str = $"在组 {id} {name} 下创建子组 {name} {path}";
                    this.AddLog(str);
                    ForkGroup(id, newGpid);
                }
            }
            var projects = _gitlabApis.GetProjects(fromId);
            if (projects != null && projects.Count > 0)
            {
                projects.ForEach(x =>
                {
                    var id = x.id.ToString();
                    var name = x.name.ToString();
                    _gitlabApis.ForkProject(id, toGp);

                    string str = $"移动项目 {id} {name} 到组 {toGp}";
                    this.AddLog(str);
                });
            }
        }

        private void AddLog(string log)
        {
            if (string.IsNullOrEmpty(log))
            {
                return;
            }
            this.txtLogs.Invoke(() =>
            {
                this.txtLogs.Text += "\r\n" + log;
                this.txtLogs.Select(this.txtLogs.TextLength, 0);
                this.txtLogs.ScrollToCaret();
            });
        }
    }
}