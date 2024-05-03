﻿using E_Project_3_API.DTO.Error;

namespace E_Project_3_API.DTO.Response
{
    public class ShowtimeResponse
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        
    }

    public class ShowtimeModifyResponse
    {
        public bool IsModified { get; set; } = false;
        public ShowtimeError Error { get; set; } = new ShowtimeError();
    }
}
