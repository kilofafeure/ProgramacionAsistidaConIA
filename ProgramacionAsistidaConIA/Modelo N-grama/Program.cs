var model = new Dictionary<string, Dictionary<string, int>>();
var textx = new[] { 
    "La ia aprende patrones",
    "La ia aprende rápidamente",
    "La ia predice textos",
    "La ia falla aveces",
};

foreach (var text in textx)
{
    var tokens = text.Split(' ');
    for (int i = 0; i < tokens.Length - 1; i++)
    {
        var current = tokens[i];
        var next = tokens[i + 1];

        if (!model.ContainsKey(current))
        {
            model[current] = []; // [] -> new Dictionary<string, int>()
        }

        if (!model[current].ContainsKey(next))
        {
            model[current][next] = 0;
        }

        model[current][next]++;
    }
}

// Predict the next word based on the current word
string PredictNextWord(string word)
{
    if (!model.ContainsKey(word))
    {
        return "No prediction available";
    }

    string best = "";
    int max = 0;

    foreach(var nextWord in model[word])
    {
        if (nextWord.Value > max)
        {
            max = nextWord.Value;
            best = nextWord.Key;
        }
    }

    return best;
}

var nextWord = PredictNextWord("ia");
Console.WriteLine($"Predicted next word: {nextWord}");

var nextWord2 = PredictNextWord("falla");
Console.WriteLine($"Predicted next word: {nextWord2}");

var nextWord3 = PredictNextWord("aveces");
Console.WriteLine($"Predicted next word: {nextWord3}");