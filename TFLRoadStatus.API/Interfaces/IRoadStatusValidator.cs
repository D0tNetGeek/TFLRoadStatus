﻿namespace TFLRoadStatus.API.Interfaces
{
    public interface IRoadStatusValidator
    {
        int GetCurrentRoadStatus(string road);
    }
}