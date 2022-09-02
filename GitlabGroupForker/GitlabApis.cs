using AgileHttp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitlabGroupForker
{
    internal class GitlabApis
    {
        private string _host = "";
        private string _token = "";
        private string _username = "";
        private string _password = "";

        public GitlabApis()
        {
            var json = File.ReadAllText("appsettings.json");
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            _host = obj.gitlab.ToString();
            _username = obj.username.ToString();
            _password = obj.password.ToString();
        }

        public bool Login()
        {
            try
            {
                _token = GetToken();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<dynamic> GetProjects()
        {
            var url = _host + "/api/v4/projects?access_token=" + _token;
            var pojects = HTTP.Send(url).Deserialize<List<dynamic>>();

            return pojects;
        }

        public List<dynamic> GetProjects(string gpId)
        {
            var url = _host + $"/api/v4/groups/{gpId}/projects?access_token=" + _token;
            var pojects = HTTP.Send(url).Deserialize<List<dynamic>>();

            return pojects;
        }

        public List<dynamic> GetGroups()
        {
            var url = _host + "/api/v4/groups?access_token=" + _token;
            var pojects = HTTP.Send(url).Deserialize<List<dynamic>>();

            return pojects;
        }

        public string GetGroup(string id)
        {
            var url = _host + $"/api/v4/groups/{id}?access_token=" + _token;
            var str = HTTP.Send(url).GetResponseContent();

            return str;
        }

        public string GetToken()
        {
            var url = _host + "/oauth/token";
            var reuslt = HTTP.Send(url, "POST", new
            {
                grant_type = "password",
                username = _username,
                password = _password
            }
            ,
            new RequestOptions
            {
                Headers = new Dictionary<string, string>() {
                    {
                        "Content-Type","application/json"
                    }
                }
            }
            ).Deserialize<dynamic>();

            return reuslt.access_token;
        }

        public List<dynamic> GetSubGroups(string id)
        {
            var url = _host + $"/api/v4/groups/{id}/subgroups?access_token=" + _token;
            var gps = HTTP.Send(url).Deserialize<List<dynamic>>();

            return gps;
        }

        public void ForkProject(string pjId, string toGp)
        {
            var url = _host + $"/api/v4/projects/{pjId}/fork?access_token=" + _token;
            var reuslt = HTTP.Send(url, "POST", new
            {
                id = pjId,
                namespace_id = toGp
            }
           ,
           new RequestOptions
           {
               Headers = new Dictionary<string, string>() {
                    {
                        "Content-Type","application/json"
                    }
               }
           }
           );
            string resp = reuslt.GetResponseContent();
        }

        public string CreateSGp(string path, string name, string parent_id)
        {
            var url = _host + $"/api/v4/groups?access_token=" + _token;
            var reuslt = HTTP.Send(url, "POST", new
            {
                path = path,
                parent_id = parent_id,
                name = name
            }
           ,
           new RequestOptions
           {
               Headers = new Dictionary<string, string>() {
                    {
                        "Content-Type","application/json"
                    }
               }
           }
           );
            var respStr = reuslt.GetResponseContent();
            var resp = JsonConvert.DeserializeObject<dynamic>(respStr);
            return resp.id.ToString();
        }
    }
}
