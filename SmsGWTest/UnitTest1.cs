using SmsGateWayApi;

namespace SmsGWTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var lampSms = new LampushGateWay("AhloncoTogo", "e7jnZF6BjU3X9a7", "SIGAEC");
        try
        {
            await lampSms.SendMessage("Test from console", "+22890913661");
         
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Assert.Fail();
        }
    }
}