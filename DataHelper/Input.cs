namespace w2_assignment_ksteph.DataHelper;

using System.Diagnostics;

// The DataHelper.Input class contains a few methods and overrides that assist in gaining input from the user that includes different levels of input validation.

class Input
{

    public static int GetInt(string question)
    {
        int response;
        do
        {
            Console.Write(question);
            try
            {
                response = Convert.ToInt32(Console.ReadLine());
                return response;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("That number is not valid. Please try again. (Please enter a valid integer)");
                continue;
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("That number is not valid. Please try again. (That number is either too big or too small)");
                continue;
            }
        } while (true);
    }

    public static int GetInt(string question, int minValue, string minValueErrorMessage)
    {
        int response;
        do
        {
            response = GetInt(question);
            if (response < minValue)
            {
                Console.WriteLine($"That number is not valid. Please try again. ({minValueErrorMessage})");
                continue;
            }
            else
            {
                return response;
            }
        } while (true);
    }

    public static int GetInt(string question, int minValue, int maxValue, string minValueErrorMessage, string maxValueErrorMessage)
    {
        int response;
        do
        {
            response = GetInt(question, minValue, minValueErrorMessage);
            if (response > maxValue)
            {
                Console.WriteLine($"That number is not valid. Please try again. ({maxValueErrorMessage})");
                continue;
            }
            else
            {
                return response;
            }
        } while (true);
    }

    public static int GetInt(int minValue, int maxValue, string minValueErrorMessage, string maxValueErrorMessage)
    {
        int response;
        do
        {
            response = GetInt("", minValue, minValueErrorMessage);
            if (response > maxValue)
            {
                Console.WriteLine($"That number is not valid. Please try again. ({maxValueErrorMessage})");
                continue;
            }
            else
            {
                return response;
            }
        } while (true);
    }

    public static int GetInt(int minValue, int maxValue, string valueErrorMessage)
    {
        int response;
        do
        {
            response = GetInt("", minValue, valueErrorMessage);
            if (response > maxValue)
            {
                Console.WriteLine($"That number is not valid. Please try again. ({valueErrorMessage})");
                continue;
            }
            else
            {
                return response;
            }
        } while (true);
    }

    public static string GetString(string prompt)
    {
        string? response = GetString(prompt, true);
        return response;
    }

    public static string GetString(string prompt, bool entryRequired)
    {
        Console.Write(prompt);
        string? response = Console.ReadLine();

        while (response == null || response == "" && entryRequired)
        {
            Console.WriteLine("Please enter an allowed value. (Value cannot be blank)");
            Console.Write(prompt + " ");
            response = Console.ReadLine();
        }

        return response;
    }

    public static string GetString(string prompt, List<string> allowedResponsesList)
    {
        string? response;

        do
        {
            Console.Write(prompt);
            response = Console.ReadLine();

            if (IsNull(response, out string errorMessage))
            {
                InvalidValue(errorMessage);
                continue;
            }

            if (IsEmpty(response, out errorMessage))
            {
                InvalidValue(errorMessage);
                continue;
            }

            if (!IsResponseAllowed(response, allowedResponsesList, out errorMessage))
            {
                InvalidValue(errorMessage);
                continue;
            }

            break;
        } while (true);

        /* This is here to remove the possibly null console warning.
           response == null should be unreachable                    */
        if (response != null)
        {
            return response.ToUpper();
        }
        else
        {
            throw new UnreachableException();
        }
    }

    public static string GetYN(string prompt)
    {
        List<string> allowedResponsesList = ["y", "n"];
        string? response;

        do
        {
            Console.Write(prompt);
            response = Console.ReadLine();

            if (IsNull(response, out string errorMessage))
            {
                InvalidValue(errorMessage);
                continue;
            }

            if (IsEmpty(response, out errorMessage))
            {
                InvalidValue(errorMessage);
                continue;
            }

            if (!IsResponseAllowed(response, allowedResponsesList, out errorMessage))
            {
                InvalidValue(errorMessage);
                continue;
            }

            break;
        } while (true);

        /* This is here to remove the possibly null console warning.
           response == null should be unreachable                    */
        if (response != null)
        {
            return response.ToUpper();
        }
        else
        {
            throw new UnreachableException();
        }
    }

    private static bool IsResponseAllowed(string? response, List<string> allowedResponsesList, out string errorMessage)
    {
        foreach (string allowedResponse in allowedResponsesList)
        {
            if (response == allowedResponse)
            {
                errorMessage = " Please enter an allowed value.";
                return true;
            }
        }
        errorMessage = " Please enter an allowed value.";
        return false;
    }

    private static bool IsEmpty(string? value)
    {
        if (value == "")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool IsEmpty(string? value, out string errorMessage)
    {
        if (value == "")
        {
            errorMessage = " The value you entered was empty.";
            return true;
        }
        else
        {
            errorMessage = " The value you entered was not empty.";
            return false;
        }
    }

    private static bool IsNull(string? value)
    {
        if (value == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static bool IsNull(string? value, out string errorMessage)
    {
        if (value == null)
        {
            errorMessage = " The value you entered was null.";
            return true;
        }
        else
        {
            errorMessage = " The value you entered was not null.";
            return false;
        }
    }

    private static void InvalidValue(string errorMessage)
    {
        Console.WriteLine($"Invalid value." + errorMessage);
    }

}
