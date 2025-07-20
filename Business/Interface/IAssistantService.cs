using e_Shift.Models;
using System.Collections.Generic;

namespace e_Shift.Business.Interface
{
    public interface IAssistantService
    {
        void AddAssistant(Assistant assistant);
        void UpdateAssistant(Assistant assistant);
        void DeleteAssistant(int assistantId);
        List<Assistant> GetAllAssistants();
        Assistant GetAssistantById(int assistantId);
        bool ValidateAssistant(Assistant assistant, out string errorMessage);
    }
}