using SmsGateWayApi;

namespace SmsGWTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestSendSms()
    {
        var lampSms = new LampushGateWay("AhloncoTogo", "e7jnZF6BjU3X9a7", "LAM");
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
        [Test]
    public void TestRequestClass()
    {
        var request = new SmsRequest
        {
            Accountid = "A",
            Password = "Pass",Sender = "Taas",Text = "Hello world",Receiver = new []{"90","91"},
        };
        var result = request.ToJson();
        Console.WriteLine(result);
    }
}