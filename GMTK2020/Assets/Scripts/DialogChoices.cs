

public class DialogChoices
{
    public string text;
    public int speech;
    public int[] next = new int[3];

    public DialogChoices(string textIn, int speechIn, int next0, int next1, int next2)
    {
        text = textIn;
        speech = speechIn;
        next[0] = next0;
        next[1] = next1;
        next[2] = next2;
    }
}
