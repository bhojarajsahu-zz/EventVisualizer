using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventVisualizer
{
    public class CobolFormatLibrary
    {
        private string ExpandFormat(string format)
        {
            string newformat = "", temp = "";
            int size = 0;
            char type = ' ';

            try
            {
                if (!format.Contains('('))
                {
                    if (format.Contains(')'))
                    {
                        return "###There are no opening braces";
                    }
                    return format;
                }

                string[] splitstring = format.Split('(', ')');

                for (int i = 1; i < splitstring.Length; i += 2)
                {
                    if (!int.TryParse(splitstring[i], out size))
                    {
                        return "###The Size should be a integer value";
                    }

                    if (i == splitstring.Length - 1)
                    {
                        //there is something wrong
                        return "###There are no closing braces";
                    }
                    type = splitstring[i - 1].Substring(splitstring[i - 1].Length - 1, 1).ToCharArray()[0];

                    newformat += splitstring[i - 1];
                    temp = string.Empty;
                    temp = temp.PadRight(size - 1, type);
                    newformat += temp;
                    if (i + 1 == splitstring.Length - 1)
                    {
                        newformat += splitstring[i + 1];
                    }
                }

                return newformat;
            }
            catch (Exception ex)
            {
                return "###" + ex.Message;
            }
        }

        public string ConvertToByteString(string input, string format)
        {
            try
            {
                format = format.ToUpper();
                input = input.ToUpper();

                format = ExpandFormat(format);
                if (format.Contains("###"))
                {
                    return format;
                }
                string output = string.Empty;


                if (format.Contains('9')) //if the format is for decimal
                {
                    //error check
                    if (format.Contains("X"))
                    {
                        return "###Incorrect cobol format.";
                    }
                    int sign = 0;
                    if (format.Contains('S'))
                    {
                        if (format.Substring(0, 1) == "S")
                        {
                            sign = 1; // sign at start
                        }
                        else if (format.Substring(format.Length - 1, 1) == "S")
                        {
                            sign = 2; // sign at end
                        }
                        else
                        {
                            //error
                            return "###Sign cannot be in the middle ";
                        }
                    }
                    string[] formatarray = format.Split('V', '.');
                    string[] inputarray = input.Split('.');

                    if (inputarray.Length > 2 || formatarray.Length > 2) //either of the input is wrong. return blank
                    {
                        return "###Incorrect cobol format.";
                    }
                    else if ((inputarray.Length == 1 && formatarray.Length == 1) // If there are no decimals in the format
                        || (inputarray.Length > formatarray.Length)) //OR input contains more items than format, truncate after first decimal point
                    {
                        if (inputarray[0].Length > formatarray[0].Length) //truncate if the input greater than format.
                        {
                            inputarray[0] = inputarray[0].Substring(0, formatarray[0].Length);
                        }
                        if (sign > 0)
                            output = inputarray[0].PadLeft(formatarray[0].Length - 1, '0');
                        else
                            output = inputarray[0].PadLeft(formatarray[0].Length, '0');

                    }
                    else if ((inputarray.Length == 2 && formatarray.Length == 2) // If there is 1 decimal in the format
                        || (inputarray.Length < formatarray.Length)) //OR format contains more items than input, add the values after decimal point as '0'
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (i < inputarray.Length && inputarray[i].Length > formatarray[i].Length) //truncate if the input greater than format.
                            {
                                inputarray[i] = inputarray[i].Substring(0, formatarray[i].Length);
                            }
                            if (i == 0)
                            {
                                output = inputarray[i].PadLeft(formatarray[i].Length, '0');
                                if (format.Contains('.'))
                                    output += ".";
                            }
                            else
                            {
                                if (inputarray.Length < formatarray.Length)
                                {
                                    if (sign > 0)
                                        output += string.Empty.PadRight(formatarray[i].Length - 1, '0');
                                    else
                                        output += string.Empty.PadRight(formatarray[i].Length, '0');
                                }
                                else
                                {
                                    if (sign > 0)
                                        output += inputarray[i].PadRight(formatarray[i].Length - 1, '0');
                                    else
                                        output += inputarray[i].PadRight(formatarray[i].Length, '0');
                                }
                            }
                        }
                    }

                    if (sign > 0)
                    {
                        string signindicator = (double.Parse(input) >= 0) ? "+" : "-";
                        output = (sign == 1) ? (signindicator + output) : (output + signindicator);
                    }
                }
                else if (format.Contains('X')) //if the format is for string.
                {
                    if (input.Length > format.Length) //truncate if the format greater than input.
                    {
                        input = input.Substring(0, format.Length);
                    }

                    output = input.PadRight(format.Length);
                }
                else if (format.Contains('D')) //date bitch
                {
                    string[] inputarray = input.Split('/');
                    if (inputarray.Length != 3)
                    {
                        return "###Incorrect date format.";
                    }


                    if (inputarray[0].Length > 2)
                    {
                        inputarray[0] = inputarray[0].Substring(inputarray[0].Length - 2, 2);
                    }

                    if (inputarray[1].Length > 2)
                    {
                        inputarray[1] = inputarray[1].Substring(inputarray[1].Length - 2, 2);
                    }


                    if (format == "DDMMYYYY")
                    {
                        if (inputarray[2].Length < 4)
                        {
                            inputarray[2] = inputarray[2].PadLeft(4, '0');
                        }
                        else if (inputarray[2].Length > 4)
                        {
                            inputarray[2] = inputarray[2].Substring(inputarray[2].Length - 4, 4);
                        }


                        output = inputarray[0].PadLeft(2, '0') + inputarray[1].PadLeft(2, '0') + inputarray[2].PadLeft(4, '0');
                    }
                    else if (format == "DDMMYY")
                    {
                        if (inputarray[2].Length < 2)
                        {
                            inputarray[2] = inputarray[2].PadLeft(2, '0');
                        }
                        else if (inputarray[2].Length > 2)
                        {
                            inputarray[2] = inputarray[2].Substring(inputarray[2].Length - 2, 2);
                        }
                        output = inputarray[0].PadLeft(2, '0') + inputarray[1].PadLeft(2, '0') + inputarray[2].PadLeft(2, '0');
                    }
                    else if (format == "YYYYMMDD")
                    {
                        if (inputarray[2].Length < 4)
                        {
                            inputarray[2] = inputarray[2].PadLeft(4, '0');
                        }
                        else if (inputarray[2].Length > 4)
                        {
                            inputarray[2] = inputarray[2].Substring(inputarray[2].Length - 4, 4);
                        }
                        output = inputarray[2] + inputarray[1].PadLeft(2, '0') + inputarray[0].PadLeft(2, '0');
                    }
                    else
                    {
                        return "###Incorrect date format.";
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                return "###" + ex.Message;
            }
        }

        public int GetFormatStringLength(string format)
        {
            int size = 0;
            try
            {
                if (format.Contains('9')) //if the format is for decimal
                {
                    if (format.Contains('S'))
                    {
                        //size += 1;
                    }

                    if (format.Contains('V') || format.Contains('.'))
                    {
                        size += 1;
                    }

                    string[] formatarray = format.Split('V', '.');

                    for (int i = 0; i < formatarray.Length; i++)
                    {
                        if (!formatarray[i].Contains('('))
                        {
                            if (formatarray[i].Contains(')'))
                            {
                                return 0;
                            }
                            size += formatarray[i].Length;
                            if (formatarray[i].IndexOf("S", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                size -= 1;
                            }
                        }
                        else
                        {
                            string[] splitstring = formatarray[i].Split('(', ')');
                            for (int b = 1; b < splitstring.Length; b += 2)
                            {
                                size += Convert.ToInt32(splitstring[b]);
                                if (splitstring[b].IndexOf("S", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    size -= 1;
                                }
                            }
                        }

                    }
                }
                else if (format.Contains('X')) //if the format is for string.
                {
                    if (!format.Contains('('))
                    {
                        if (format.Contains(')'))
                        {
                            return 0;
                        }
                        size += format.Length;
                    }
                    else
                    {
                        string[] splitstring = format.Split('(', ')');
                        for (int i = 1; i < splitstring.Length; i += 2)
                        {
                            size += Convert.ToInt32(splitstring[i]);
                        }
                    }

                }
                else if (format.IndexOf("D", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    format.IndexOf("M", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    format.IndexOf("Y", StringComparison.OrdinalIgnoreCase) >= 0) //date 
                {
                    size += format.Length;
                }
            }
            catch
            {
                throw;
            }

            return size;
        }
    }
}
