using System.Threading.Tasks;

public class Trackers : EasyBase
{
    public Trackers() : base() { }

    public async override void Menu(string choice){
        
    }

    public async Task<string> CreateTrackerAsync()
    {
        string trackerJson = $@"
        {{
            // Add tracker details here
        }}";

        return await base.PostAsync("trackers", trackerJson);
    }
}