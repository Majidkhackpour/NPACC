using System;
using System.Collections.Generic;

namespace PacketParser.Services
{
    public class ReturnedSaveFuncInfo
    {
        public List<string> InformationList { get; private set; } = new List<string>();
        public List<string> ErrorList { get; private set; } = new List<string>();
        public List<string> WarningList { get; private set; } = new List<string>();

        public bool HasError => (ErrorMessage?.Length ?? 0) > 0;
        public bool HasWarning => (WarningMessage?.Length ?? 0) > 0;

        public string ErrorMessage
        {
            get
            {
                try
                {
                    return ErrorList.Count > 0 ? string.Join(Environment.NewLine, ErrorList) : "";
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    return null;
                }
            }
        }

        public string WarningMessage
        {
            get
            {
                try
                {
                    return WarningList.Count > 0 ? string.Join(Environment.NewLine, WarningList) : "";
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    return null;
                }
            }
        }

        public string InformationMessage
        {
            get
            {
                try
                {
                    return InformationList.Count > 0 ? string.Join(Environment.NewLine, InformationList) : "";
                }
                catch (Exception ex)
                {
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
                    return null;
                }
            }
        }

        public bool HasInformation => InformationList.Count > 0;

        public void SendError()
        {
        }

        public ReturnedSaveFuncInfo()
        {
        }

        public ReturnedSaveFuncInfo(Exception ex, string description = "",
            [System.Runtime.CompilerServices.CallerMemberName]
            string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath]
            string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber]
            int sourceLineNumber = 0)
        {
            try
            {
                var message = "";
                if (!string.IsNullOrEmpty(description)) message = $"Descriptin: {description} ";
                if (sourceLineNumber != 0) message += $"SourceLineNumber: {sourceLineNumber} ";
                if (!string.IsNullOrEmpty(memberName)) message += $"memberName: {memberName} ";
                if (!string.IsNullOrEmpty(sourceFilePath)) message += $"sourceFilePath: {sourceFilePath} ";

                ErrorList.Add(ex.Message + "  " + message);
            }
            catch (Exception ex2)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex2);
            }
        }

        public ReturnedSaveFuncInfo(ReturnedState information, string v)
        {
            AddReturnedValue(information, v);
        }

        public void AddReturnedValue(ReturnedState returnedState, string value)
        {
            try
            {
                switch (returnedState)
                {
                    case ReturnedState.Information:
                        InformationList.Add(value);
                        break;
                    case ReturnedState.Error:
                        ErrorList.Add(value);
                        break;
                    case ReturnedState.Warning:
                        WarningList.Add(value);
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public void ResetInformationList()
        {
            try
            {
                InformationList.Clear();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public void ResetErrorList()
        {
            try
            {
                ErrorList.Clear();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public void ResetWarningList()
        {
            try
            {
                WarningList.Clear();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public void AddReturnedValue(Exception ex)
        {
            try
            {
                ErrorList.Add(ex.Message);
            }
            catch (Exception ex2)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex2);
            }
        }

        public void AddReturnedValue(ReturnedSaveFuncInfo returnedSaveFuncInfo)
        {
            try
            {
                if (returnedSaveFuncInfo?.ErrorList?.Count > 0)
                    ErrorList.AddRange(returnedSaveFuncInfo.ErrorList);
                if (returnedSaveFuncInfo?.InformationList?.Count > 0)
                    InformationList.AddRange(returnedSaveFuncInfo.InformationList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}