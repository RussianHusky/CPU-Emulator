public class Register {
    public int PC { get; set; }
    public bool ZF { get; set; }


    public Register() {
        PC = 0;
        ZF = false;
    }
}