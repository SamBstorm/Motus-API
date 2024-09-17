using System;
using System.Collections.Generic;
using System.Text;

namespace Motus_DataAccessLayer
{
    public interface IMotusRepository
    {
        string GetRandomWord(int? wordSize = null);
        bool IsValid(string word);
    }
}
