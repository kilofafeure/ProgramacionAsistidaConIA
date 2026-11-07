var model = new Dictionary<string, Dictionary<string, int>>();
var textx = new[] {
    "El gato negro salta sobre la mesa",
    "El gato negro corre por el jardín",
    "El gato negro duerme en el sofá",
    "El gato negro juega en el parque",
    "El perro grande ladra en la noche",
    "El perro grande duerme en el patio",
    "El perro grande juega en el parque",
    "La casa blanca tiene ventanas grandes",
    "La casa blanca tiene puertas antiguas",
    "La casa blanca está en la colina",
};

foreach (var text in textx)
{
    var tokens = text.Split(' ');
    for (int i = 0; i < tokens.Length - 2; i++)
    {
        var current = tokens[i] + " " + tokens[i+1];
        var next = tokens[i + 2];

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
string PredictNextWord(string word1, string word2)
{
    var context = word1 + " " + word2;

    if (!model.ContainsKey(context))
    {
        return "No prediction available";
    }

    string best = "";
    int max = 0;

    foreach (var nextWord in model[context])
    {
        if (nextWord.Value > max)
        {
            max = nextWord.Value;
            best = nextWord.Key;
        }
    }

    return best;
}

var nextWord = PredictNextWord("El", "gato");
Console.WriteLine($"Predicted next word: {nextWord}");

var nextWord2 = PredictNextWord("gato", "negro");
Console.WriteLine($"Predicted next word: {nextWord2}");

var nextWord3 = PredictNextWord("blanca", "tiene");
Console.WriteLine($"Predicted next word: {nextWord3}");