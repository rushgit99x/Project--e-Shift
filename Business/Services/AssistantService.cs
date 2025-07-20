using e_Shift.Business.Interface;
using e_Shift.Models;
using e_Shift.Repository.Interface;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace e_Shift.Business.Services
{
    public class AssistantService : IAssistantService
    {
        private readonly IAssistantRepository _assistantRepository;

        public AssistantService(IAssistantRepository assistantRepository)
        {
            _assistantRepository = assistantRepository;
        }

        public void AddAssistant(Assistant assistant)
        {
            _assistantRepository.Add(assistant);
        }

        public void UpdateAssistant(Assistant assistant)
        {
            _assistantRepository.Update(assistant);
        }

        public void DeleteAssistant(int assistantId)
        {
            _assistantRepository.Delete(assistantId);
        }

        public List<Assistant> GetAllAssistants()
        {
            return _assistantRepository.GetAll();
        }

        public Assistant GetAssistantById(int assistantId)
        {
            return _assistantRepository.GetById(assistantId);
        }

        public bool ValidateAssistant(Assistant assistant, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(assistant.FirstName))
            {
                errorMessage = "First Name is required.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(assistant.LastName))
            {
                errorMessage = "Last Name is required.";
                return false;
            }
            if (assistant.Status == "Select the status")
            {
                errorMessage = "Please select a valid status.";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(assistant.Phone) && !Regex.IsMatch(assistant.Phone, @"^\+?\d{10,15}$"))
            {
                errorMessage = "Please enter a valid phone number (10-15 digits, optional '+' prefix).";
                return false;
            }
            return true;
        }

    }
}