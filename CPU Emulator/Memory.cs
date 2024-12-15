public class Memory
{
    private int[] _memory; // Memory array
    private int _sp;       // Stack pointer
    private int _capacity;

    public Memory(int size)
    {
        _memory = new int[size];
        _sp = size - 1;
    }

    public void WriteCap(int capacity)
    {
        _capacity = capacity;
    }
    
    // Read and write methods
    public int Read(int address)
    {
        if (address < 0 || address >= _memory.Length)
            throw new ArgumentOutOfRangeException("Address out of bounds.");
        return _memory[address];
    }

    public void Write(int address, int value)
    {
        if (address < 0 || address >= _memory.Length)
            throw new ArgumentOutOfRangeException("Address out of bounds.");
        _memory[address] = value;
    }

    // Stack operations
    public void Push(int value)
    {
        if (_sp < 0)
            throw new StackOverflowException("Stack overflow.");
        _memory[_sp--] = value;
    }

    public int Pop()
    {
        if (_sp >= _memory.Length - 1)
            throw new InvalidOperationException("Stack underflow.");
        _memory[_sp] = 0;
        return _memory[++_sp];
    }

    public int StackPointer => _sp + 1; // Return the current stack pointer
}