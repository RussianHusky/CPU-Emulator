enum Opcode
{
    End = 0,
    Push = 1,
    Add = 2,
    Sub = 3,
    Store = 4,
    Comp = 5,
    Mul = 6,
    Load = 7,
    Jump = 8,
    JumpZ = 9,
    JumpNZ = 10,
    Pop = 11,
    Swap = 12,
    Rol = 13,
    SP = 14,
    Dup = 15
}

public class CommandHandler
{
    private Register _register;
    private Memory _memory;

    public CommandHandler(Register register, Memory memory)
    {
        _register = register;
        _memory = memory;
    }

    public void Execute(int commandAddress)
    {
        int command = _memory.Read(commandAddress);
        var opcode = (Opcode)((command >> 12) & (0xF));
        
        
        switch (opcode)
        {
            case Opcode.Dup:
                _memory.Push(_memory.StackPointer);
                break;
            
            case Opcode.Push:
                int operand = _memory.Read(_register.PC++);
                _memory.Push(operand);
                break;

            case Opcode.Add:
                _memory.Push(_memory.Pop() + _memory.Pop());
                _register.ZF = (_memory.Read(_memory.StackPointer) == 0);
                break;

            case Opcode.Comp:
                _register.ZF = _memory.Read(_memory.StackPointer) > _memory.Read(_memory.StackPointer + 1);
                break;
            
            case Opcode.Store:
                _memory.Write(_memory.Pop(), _memory.Pop());
                break;
            
            case Opcode.Load:
                _memory.Push(_memory.Read(_memory.Pop()));
                break;

            case Opcode.Jump:
                _register.PC = _memory.Read(_register.PC++);
                break;

            case Opcode.JumpZ:
                if (!_register.ZF)
                    _register.PC = _memory.Read(_register.PC++);
                else _register.PC++;
                break;

            case Opcode.JumpNZ:
                if (_register.ZF)
                    _register.PC = _memory.Read(_register.PC++);
                else _register.PC++;
                break;
            
            case Opcode.Pop:
                _memory.Pop();
                break;
            
            case Opcode.Swap:
                int top1 = _memory.Pop();
                int top2 = _memory.Pop();
                _memory.Push(top1);
                _memory.Push(top2);
                break;
            
            case Opcode.Rol:
                int[] stackValues = new int[3];
                for(int i = 0; i < 3; i++)
                    stackValues[i] = _memory.Pop();
                _memory.Push(stackValues[0]);
                _memory.Push(stackValues[2]);
                _memory.Push(stackValues[1]);
                break;
            
            case Opcode.End:
                Console.WriteLine(_memory.Pop());
                Environment.Exit(0);
                break;
            
            case Opcode.SP:
                _memory.Push(_memory.StackPointer - 1);
                break;
            
            default:
                throw new InvalidOperationException("Unknown opcode");
        }
        
    }
}