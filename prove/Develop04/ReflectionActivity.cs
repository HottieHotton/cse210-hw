public class ReflectionActivity : Activity
{
    private Random _rand;
    private string[] _prompt;
    private string[] _reflectionQuestions;

    public ReflectionActivity() : base("\nReflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n")
    {
        _rand = new Random();
        _prompt = new string[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless"
        };

        _reflectionQuestions = new string[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Start()
    {
        base.StartMessage();
    }

    public string GetPrompt()
    {
        int index = _rand.Next(_prompt.Length);
        return _prompt[index];
    }

    public void RunActivity(int time)
    {
        Console.Clear();
        base.Countdown();
        Console.Clear();
        
        Console.WriteLine(GetPrompt());
        base.PauseAnimation(3);

    }
}
