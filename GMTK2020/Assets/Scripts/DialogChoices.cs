

public class DialogChoices
{
    public string text;
    public int speech1;
    public int speech2;
    public int[] next = new int[3];

    public DialogChoices(string textIn, int speech1In, int speech2In, int next0, int next1, int next2)
    {
        text = textIn;
        speech1 = speech1In;
        speech2 = speech2In;
        next[0] = next0;
        next[1] = next1;
        next[2] = next2;
    }
}
