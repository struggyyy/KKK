using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KKK.Models
{
    public class NoteService
    {
        private readonly IDateProvider _dateProvider;
        private readonly List<Note> _notes;

        public NoteService(IDateProvider dateProvider)
        {
            _dateProvider = dateProvider;
            _notes = new List<Note>();
        }

        public void Add(Note note)
        {
            _notes.Add(note);
        }

        public List<Note> GetAll()
        {
            return _notes.Where(note => note.Deadline > _dateProvider.CurrentDate).ToList();
        }

        public Note GetById(string title)
        {
            return _notes.FirstOrDefault(note => note.Title == title && note.Deadline > _dateProvider.CurrentDate);
        }
    }
}
