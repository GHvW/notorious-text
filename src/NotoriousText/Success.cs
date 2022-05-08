namespace NotoriousText; 

public class Success<A> : Parser<A> {
    
    private readonly A item;
    
    public Success(A item) {
        this.item = item;
    }

    public (A, InputState)? Parse(InputState input) =>
        (this.item, input);
}
