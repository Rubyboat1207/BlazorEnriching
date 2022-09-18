namespace SOS.Data
{
    using Flurl.Http;
    public class FetchingStuff
    {
        public async Task<string> fetchSchedules()
        {
            return await "https://student.enrichingstudents.com/v1.0/appointment/viewschedules"
            .WithHeader("accept", "application/json, text/plain, */*")
            .WithHeader("content-type", "application/json;charset=UTF-8")
            .WithHeader("esauthtoken", "jcnwodh2:4;wueiosdzm:326;ksdfjlsnv:1271303;qdjHDnmxadf:sNk9JjOb2gjqTfPDsBB9TYZPCl8FwTyT0,XnFQ__;ofu82uicn:sNk9JjOb2gjXmj7tKuaAi983A0akKbes3oNZCA__;kosljsdnc:sNk9JjOb2ghyMLdkpw03EWZx3LmwoBE6XGCC1A__;^ydh)9xLkxx:sNk9JjOb2giqccPQoBXZnpqbMPiIGV8VO6ZZSg__")
            .PostStringAsync("{startDate: \"2022-09-19\"}")
            .ReceiveString();
        }
    }
}
