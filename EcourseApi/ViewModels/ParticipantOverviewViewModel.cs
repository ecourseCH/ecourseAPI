using System;
using EcourseApi.Models;

namespace EcourseApi.ViewModels
{
    public class ParticipantOverviewViewModel
    {
        private readonly Participant _participant;

        public ParticipantOverviewViewModel(Participant participant)
        {
            _participant = participant;
        }
        public int id => _participant.Id;
        public string Name => _participant.Name;
        public string PreName => _participant.PreName;
    }
}
