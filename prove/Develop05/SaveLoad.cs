public class SaveLoad{
    SimpleGoal simple = new SimpleGoal();
    EternalGoal eternal = new EternalGoal();
    ChecklistGoal checklist = new ChecklistGoal();

    public void SaveGoals(int score){
        Console.WriteLine("Enter the name of the file you wish you create: ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName)){
            outputFile.WriteLine(score);
            outputFile.WriteLine("Simple Goals: ");
            foreach(Object i in simple._simpleList){
                outputFile.WriteLine(i);
            }
            outputFile.WriteLine("Eternal Goals: ");
            foreach(Object i in eternal._eternalList){
                outputFile.WriteLine(i);
            }
            outputFile.WriteLine("Checklist Goals: ");
            foreach(Object i in checklist._checklistList){
                outputFile.WriteLine(i);
            }
        }

    }

    public int LoadGoals(){
        Console.WriteLine("Enter the name of the file you wish to load: ");
        string fileName = Console.ReadLine();
        string[] lines = File.ReadAllLines(fileName);

        // Initialize lists for different types of goals
        List<string> simpleGoals = new List<string>();
        List<string> eternalGoals = new List<string>();
        List<string> checklistGoals = new List<string>();

        // Read the score from line 0
        int score = int.Parse(lines[0]);

        // Index to keep track of the current line being processed
        int currentLineIndex = 1;

        // Process Simple Goals
        while (currentLineIndex < lines.Length && !lines[currentLineIndex].StartsWith("Eternal Goals:"))
        {
            simpleGoals.Add(lines[currentLineIndex]);
            currentLineIndex++;
        }

        // Process Eternal Goals
        currentLineIndex++; // Skip the line containing "Eternal Goals:"
        while (currentLineIndex < lines.Length && !lines[currentLineIndex].StartsWith("Checklist Goals:"))
        {
            eternalGoals.Add(lines[currentLineIndex]);
            currentLineIndex++;
        }

        // Process Checklist Goals
        currentLineIndex++; // Skip the line containing "Checklist Goals:"
        while (currentLineIndex < lines.Length)
        {
            checklistGoals.Add(lines[currentLineIndex]);
            currentLineIndex++;
        }

        // Display the results (you can modify this part based on your needs)
        Console.WriteLine($"Score: {score}\n");

        Console.WriteLine("Simple Goals:");
        simple.DisplayGoals();

        Console.WriteLine("\nEternal Goals:");
        eternal.DisplayGoals();

        Console.WriteLine("\nChecklist Goals:");
        checklist.DisplayGoals();
    
        return score;
    }
}