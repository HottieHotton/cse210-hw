public class ChecklistGoal : Goal{

    public List<string> _checklistList;
    private int _bonus = 100;
    private int _times;
    private int _count;

    public ChecklistGoal() : base("Checklist Goals", 5){
        _checklistList = new List<string>();
        _checklistList.Add("Clean your room");
        _checklistList.Add("50");
        _checklistList.Add("0 / 10");
        _checklistList.Add("Read your scriptures");
        _checklistList.Add("50");
        _checklistList.Add("0 / 5");
        _checklistList.Add("Do a workout");
        _checklistList.Add("50");
        _checklistList.Add("0 / 3");
    }

    public override void AddGoal(){
        string goal;
        string points;
        string times;
        _times = 0;

        Console.WriteLine("Please enter your Goal: ");
        goal = Console.ReadLine();
        _checklistList.Add(goal);

        Console.WriteLine("Please enter the points for this goal: ");
        points = Console.ReadLine();
        _checklistList.Add(points);

        Console.WriteLine("Please enter the times you want to complete this: ");
        times = Console.ReadLine();
        _checklistList.Add($"{_times} / {times}");
    }

    public override int RecordEvent(){
        int count = 0;
        int list = 0;
        int user;
        string goal;
        string line;

        Console.Clear();
        foreach (Object i in _checklistList){
            if(count%2 == 0){
                Console.WriteLine($"{list+=1}: {i}");
            }else{
                Console.WriteLine($"Points: {i}");
            }
            count++;
        }

        Console.WriteLine("\nPlease select the goal to complete: ");
        user = int.Parse(Console.ReadLine());
        goal = _checklistList[user];
        _score = int.Parse(_checklistList[user+1]);
        line = _checklistList[user+2];
        string[] arr = line.Split(" / ");
        _times = int.Parse(arr[0]);
        _count = int.Parse(arr[1]);
        _checklistList[user+2] = $"{_times++} / {_count}";
        if(_times/_count == 1){
            _score+= _bonus;
            Console.WriteLine("Bonus Added!");
            _checklistList[user+1] = $"[X] {goal}";
        }
        
        return _score;
    }

    public override void DisplayGoals(){
        int count = 0;
        int num = 1;
        foreach (Object i in _checklistList){
            if(count == 0){
                Console.WriteLine($"Goal #{num}: {i}");
            }else if(count == 1){
                Console.WriteLine($"Points: {i}");
            }else if(count == 2){
                Console.WriteLine($"Times completed: {i}");
            }
            count++;
            num++;
        }
    }
}