using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Repository.Interface
{
    public interface IAssistantRepository
    {
        void Add(Assistant assistant);
        void Update(Assistant assistant);
        void Delete(int assistantId);
        List<Assistant> GetAll();
        Assistant GetById(int assistantId);
        List<Assistant> GetAvailableAssistants();
        bool UpdateAssistantStatus(int assistantId, string status);
        List<Assistant> GetAllAssistants();
        void AddAssistant(Assistant assistant);
        bool UpdateAssistant(Assistant assistant);
        bool DeleteAssistant(int assistantId);
    }
}