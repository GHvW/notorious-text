namespace NotoriousText; 

public class Item : IParser<char> {
    
    public Item() {}

    public (char, InputState)? Parse(InputState input) {
        if (input.Position == input.Input.Length - 1) {
            return null;
        } else {
            return (input.Input[input.Position], input with { Position = input.Position + 1 });
        }
    }
}
