public class CPU
{
    public Register Registers { get; private set; }
    public Memory Memory { get; private set; }
    private CommandHandler _commandHandler;
    Dictionary<string, int> labelAddresses = new();
    
    public CPU(int memorySize)
    {
        Registers = new Register();
        Memory = new Memory(memorySize);
        _commandHandler = new CommandHandler(Registers, Memory);
    }

    public void LoadProgram(string[] program, int[] data)
    {
        

        int i = 0;
        
        foreach (var command in program)
        {
            string[] input = command.Split();

            if (input.Length == 1 && input[0].EndsWith(":"))
            {
                string label = input[0].TrimEnd(':');
                labelAddresses[label] = i;
                continue;
            }
            else if (input.Length == 2)
            {
                i += 2;
            }
            else if (input.Length == 1) i++;
        }
        
        labelAddresses.Add("Data", i += 2);

        i = 0;
        
        foreach (var command in program)
        {
            string[] input = command.Split();

            if (input.Length == 1 && input[0].EndsWith(":")) // Label
            {
                string label = input[0].TrimEnd(':');
                labelAddresses[label] = i; // Map label to current address
                continue;
            }

            if (input.Length == 1)
            {
                Opcode.TryParse(input[0], out Opcode opcode);
                Memory.Write(i, (int)opcode << 12);
            }
            else
            {
                if (Opcode.TryParse(input[0], out Opcode opcode))
                {
                    Memory.Write(i, (int)opcode << 12);
                    if (int.TryParse(input[1], out int operand))
                    {
                        Memory.Write(++i, operand);
                    }
                    else
                    {
                        Memory.Write(++i, labelAddresses[input[1]]);
                    }
                }
            }
            i++;
        }
        
        
        i += 2;
        foreach (var input in data)
        {
            Memory.Write(i, input);
            i++;
        }
        
    }

    public void Run()
    {
        while (true)
        {
            if (Memory.Read(Registers.PC) >= 4096)
            {
                var opcode = (Opcode)((Memory.Read(Registers.PC) >> 12) & (0xF));
                Console.WriteLine(opcode.ToString() + " " + Memory.Read(Registers.PC + 1));
            }
            _commandHandler.Execute(Registers.PC++);
            Console.WriteLine("[ " + Memory.Read(61) + " " + Memory.Read(62) + " " + Memory.Read(63) + " ]");
        }
    }
}