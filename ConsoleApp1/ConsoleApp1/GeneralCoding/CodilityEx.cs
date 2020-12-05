using System.Linq;

namespace ArgsProblem.Tests
{
    public class ValidateArguments
    {

        private const int WRONG_ARGS = -1;
        private const int OK_ARGS = 0;
        private const int HELP_ARGS = 1;
        private const string NAME_ARG = "--NAME";
        private const string COUNT_ARG = "--COUNT";
        private const string HELP_ARG = "--HELP";
        public static void Main(string[] args)
        {
            Validate(args);
        }
        public static int Validate(string[] args)
        {
            // throw new System.ArgumentException("Not yet implemented");
            var help_present = false;
            var args_valid = true;
            if (args == null || args.Length == 0)
            {
                return WRONG_ARGS;
            }
            else
            {
                for (var i = 0; i < args.Length;)
                {
                    var arg = args[i].ToUpperInvariant();
                    if (arg == NAME_ARG)
                    {
                        if (i + 1 >= args.Length)
                        {
                            args_valid = false;
                            break;
                        }
                        // we do not care whats up next
                        var val = args[i + 1];
                        if (val.Length <= 3 || val.Length >= 10)
                        {
                            args_valid = false;
                            break;
                        }
                        i += 2;
                    }
                    else if (arg == COUNT_ARG)
                    {
                        if (i + 1 >= args.Length)
                        {
                            args_valid = false;
                            break;
                        }
                        var val = args[i + 1];
                        int count = -1;
                        if (!int.TryParse(val, out count))
                        {
                            args_valid = false;
                            break;
                        }
                        if (count < 10 || count > 100)
                        {
                            args_valid = false;
                            break;
                        }
                        i += 2;
                    }
                    else if (arg == HELP_ARG)
                    {
                        help_present = true;
                        i += 1;
                    }
                    else
                    {
                        args_valid = false;
                        break;
                    }
                }

                if (help_present)
                {
                    args_valid = true;
                }
                if (args_valid)
                {
                    if (help_present)
                    {
                        return HELP_ARGS;
                    }
                    return OK_ARGS;
                }
            }
            return WRONG_ARGS;
        }
    }

}


