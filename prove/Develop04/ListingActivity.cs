public class ListingActivity : Activity
{
    private string[] _listingQuestion;
    private Random _rand;
    private List<string> _response;
    private string _user;

    public ListingActivity(): base("\nListing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n"){
        _rand = new Random();
        _listingQuestion = new string[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _response = new List<string>();
    }
    public void Start()
    {
        base.StartMessage();
    }

    public void RunActivity(int time){
        Console.Clear();
        base.Countdown();
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(time+2);
        DateTime currentTime = DateTime.Now;
        int counter = 0;

        Console.WriteLine("For the following question, please enter as many responses as you can. Hit enter when done with one response!\n");
        int index = _rand.Next(_listingQuestion.Length);
        Console.WriteLine(_listingQuestion[index]);

        base.PauseAnimation(2);
        Console.WriteLine("Begin!");
        while(currentTime<futureTime){
            counter++;
            Console.WriteLine($"Response #{counter}: ");
            _user = Console.ReadLine();
            _response.Add(_user);
            currentTime = DateTime.Now;
        };

        base.EndMessage($"Completed! You finished this activity in {time} seconds!");
        base.EndMessage($"\nHere are the responses for the following question: {_listingQuestion[index]}");
        foreach (string i in _response){
            base.EndMessage(i);
        }
        Thread.Sleep(5000);
    }
}