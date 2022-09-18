namespace SOS.Data
{
    using Flurl.Http;
    using Newtonsoft.Json.Linq;
    using System.Text.RegularExpressions;
    public class Client
    {
        public async Task<string> fetchSchedules(EnrichedDate date)
        {
            return await "https://student.enrichingstudents.com/v1.0/appointment/viewschedules"
            .WithHeader("accept", "application/json, text/plain, */*")
            .WithHeader("content-type", "application/json;charset=UTF-8")
            .WithHeader("esauthtoken", "jcnwodh2:4;wueiosdzm:326;ksdfjlsnv:1271303;qdjHDnmxadf:sNk9JjOb2gjqTfPDsBB9TYZPCl8FwTyT0,XnFQ__;ofu82uicn:sNk9JjOb2gjXmj7tKuaAi983A0akKbes3oNZCA__;kosljsdnc:sNk9JjOb2ghyMLdkpw03EWZx3LmwoBE6XGCC1A__;^ydh)9xLkxx:sNk9JjOb2giqccPQoBXZnpqbMPiIGV8VO6ZZSg__")
            .PostStringAsync("{startDate: \"" + date.getDate() + "\"}")
            .ReceiveString();
        }

        public async Task<string> fetchScheduleable(EnrichedDate date, ModSlot slot)
        {
            Console.WriteLine("{\"periodId\":" + slot.id + ",\"startDate\":\"" + date.getDate() + "\"}");
            return await "https://student.enrichingstudents.com/v1.0/course/forstudentscheduling"
            .WithHeader("accept", "application/json, text/plain, */*")
            .WithHeader("content-type", "application/json;charset=UTF-8")
            .WithHeader("esauthtoken", "jcnwodh2:4;wueiosdzm:326;ksdfjlsnv:1271303;qdjHDnmxadf:sNk9JjOb2gjqTfPDsBB9TYZPCl8FwTyT0,XnFQ__;ofu82uicn:sNk9JjOb2gjXmj7tKuaAi983A0akKbes3oNZCA__;kosljsdnc:sNk9JjOb2ghyMLdkpw03EWZx3LmwoBE6XGCC1A__;^ydh)9xLkxx:sNk9JjOb2giqccPQoBXZnpqbMPiIGV8VO6ZZSg__")
            .PostStringAsync("{\"periodId\":" + slot.id + ",\"startDate\":\"" + date.getDate() + "\"}")
            .ReceiveString();
        }


        public List<Course> toCourseList(string json)
        {
            List<Course> courses = new List<Course>();
            JArray jsonObject = JArray.Parse(json);
            foreach (JToken course in jsonObject[0]["details"].Children())
            {
                Course completedCourse = new Course();
                completedCourse.name = course["courseName"].ToString();
                if (course["instructorFirstName"] != null)
                {
                    completedCourse.facilitator_name = course["instructorFirstName"] + ", " + course["instructorLastName"];
                }
                completedCourse.period_id = ModSlot.getMod(course["periodId"].Value<int>());
                completedCourse.room = course["courseRoom"].ToString();
                courses.Add(completedCourse);
            }
            return courses;
        }

        public List<Mod> toSchedulableList(string json,ModSlot slot, EnrichedDate date)
        {
            List<Mod> mods = new List<Mod>();
            JObject jsonObject = JObject.Parse(json);
            foreach (JToken course in jsonObject["courses"].Children())
            {
                Course completedCourse = new Course();
                bool availiable = true;
                if (!course["isOpenForScheduling"].Value<bool>() || course["maxNumberStudents"].Value<int>() <= 0 || course["courseName"].ToString() == "This course does not allow for student self-scheduling")
                {
                    availiable = false;
                }
                completedCourse.name = course["courseName"].ToString();
                var regex = Regex.Split(completedCourse.name, "[-:]");
                if (regex.Length >= 2)
                {
                    completedCourse.name = regex[1].Trim();
                }
                if (course["instructorFirstName"] != null)
                {
                    completedCourse.facilitator_name = course["instructorFirstName"] + ", " + course["instructorLastName"];
                }
                completedCourse.period_id = slot;
                completedCourse.description = course["courseDescription"].ToString();
                completedCourse.room = course["courseRoom"].ToString();
                mods.Add(new Mod(completedCourse, 
                    course["maxNumberStudents"].Value<int>(), 
                    date, 
                    availiable
                ));
            }
            return mods;
        }
        
    }
}
