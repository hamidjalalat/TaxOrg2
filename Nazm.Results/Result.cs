﻿
namespace Nazm.Results
{
    //public class Result : object
    //{
    //    public Result() : base()
    //    {
    //        IsSuccess = true;
    //        IsFailed = false;

    //        _errors =
    //            new System.Collections.Generic.List<string>();

    //        _successes =
    //            new System.Collections.Generic.List<string>();
    //    }

    //    public bool IsFailed { get; set; }

    //    public bool IsSuccess { get; set; }

    //    [System.Text.Json.Serialization.JsonIgnore]
    //    private readonly System.Collections.Generic.List<string> _errors;

    //    public System.Collections.Generic.IReadOnlyList<string> Errors
    //    {
    //        get
    //        {
    //            return _errors;
    //        }
    //    }

    //    [System.Text.Json.Serialization.JsonIgnore]
    //    private readonly System.Collections.Generic.List<string> _successes;

    //    public System.Collections.Generic.IReadOnlyList<string> Successes
    //    {
    //        get
    //        {
    //            return _successes;
    //        }
    //    }

    //    public void AddErrorMessage(string message)
    //    {
    //        message =
    //            String.Fix(text: message);

    //        if (message == null)
    //        {
    //            return;
    //        }

    //        if (_errors.Contains(message))
    //        {
    //            return;
    //        }

    //        _errors.Add(message);

    //        IsFailed = true;
    //        IsSuccess = false;
    //    }

    //    public void RemoveErrorMessage(string message)
    //    {
    //        message =
    //            String.Fix(text: message);

    //        if (message == null)
    //        {
    //            return;
    //        }

    //        _errors.Remove(message);

    //        if (_errors.Count == 0)
    //        {
    //            IsFailed = false;
    //            IsSuccess = true;
    //        }
    //    }

    //    public void ClearErrorMessages()
    //    {
    //        IsFailed = false;
    //        IsSuccess = true;

    //        _errors.Clear();
    //    }

    //    public void AddSuccessMessage(string message)
    //    {
    //        message =
    //            String.Fix(text: message);

    //        if (message == null)
    //        {
    //            return;
    //        }

    //        if (_successes.Contains(message))
    //        {
    //            return;
    //        }

    //        _successes.Add(message);
    //    }

    //    public void RemoveSuccessMessage(string message)
    //    {
    //        message =
    //            String.Fix(text: message);

    //        if (message == null)
    //        {
    //            return;
    //        }

    //        _successes.Remove(message);
    //    }

    //    public void ClearSuccessMessages()
    //    {
    //        _successes.Clear();
    //    }

    //    public void ClearAllMessages()
    //    {
    //        ClearErrorMessages();
    //        ClearSuccessMessages();
    //    }
    //}

    public class Result : object
    {
        public Result() : base()
        {
            IsSuccess = true;
            IsFailed = false;

            Errors =
                new System.Collections.Generic.List<string>();

            Successes =
                new System.Collections.Generic.List<string>();
        }

        public bool IsFailed { get; set; }

        public bool IsSuccess { get; set; }

        public System.Collections.Generic.IList<string> Errors { get; set; }

        public System.Collections.Generic.IList<string> Successes { get; set; }


        public void AddErrorMessage(string message)
        {
            message =
                String.Fix(text: message);

            if (message == null)
            {
                return;
            }

            if (Errors.Contains(message))
            {
                return;
            }

            Errors.Add(message);

            IsFailed = true;
            IsSuccess = false;
        }

        public void RemoveErrorMessage(string message)
        {
            message =
                String.Fix(text: message);

            if (message == null)
            {
                return;
            }

            Errors.Remove(message);

            if (Errors.Count == 0)
            {
                IsFailed = false;
                IsSuccess = true;
            }
        }

        public void ClearErrorMessages()
        {
            IsFailed = false;
            IsSuccess = true;

            Errors.Clear();
        }

        public void AddSuccessMessage(string message)
        {
            message =
                String.Fix(text: message);

            if (message == null)
            {
                return;
            }

            if (Successes.Contains(message))
            {
                return;
            }

            Successes.Add(message);
        }

        public void RemoveSuccessMessage(string message)
        {
            message =
                String.Fix(text: message);

            if (message == null)
            {
                return;
            }

            Successes.Remove(message);
        }

        public void ClearSuccessMessages()
        {
            Successes.Clear();
        }

        public void ClearAllMessages()
        {
            ClearErrorMessages();
            ClearSuccessMessages();
        }
    }
}
