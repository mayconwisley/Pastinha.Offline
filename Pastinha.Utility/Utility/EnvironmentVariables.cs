using Pastinha.Utility.Constant;

namespace Pastinha.Utility.Utility;

public static class EnvironmentVariables
{
    public static bool IsVariableBD(string variable)
    {
        var isVariable = string.Equals(Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine), Constants.PASTINHA_BD);
        return isVariable;
    }
    public static bool IsVariableKey(string variable)
    {
        var isVariable = string.Equals(Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine), Constants.PASTINHA_KEY);
        return isVariable;
    }
    public static string GetVariable(string variable)
    {
        var getVariable = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
        if (!string.IsNullOrEmpty(getVariable))
        {
            return getVariable;
        }
        return string.Empty;
    }

}
