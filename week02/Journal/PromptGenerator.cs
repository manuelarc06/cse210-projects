public class PromptGenerator
{
    public List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>()
        {
            "What was the biggest challenge I faced today?",
            "What made me smile today?",
            "What is one thing I want to improve tomorrow?",
            "What was the best food that you had today?",
            "What is something I learned about myself today?",
            "What moment today do I want to remember?"
        };
    }

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(0, _prompts.Count);
        string randomPrompt = _prompts[index];

        return randomPrompt;
    }
}