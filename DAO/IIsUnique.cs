using Phonebook.Models;

namespace Phonebook.DAO
{
    interface IIsUnique
    {
        //interface for CheckUnique class
        bool CheckUnique(NewRecord model);
    }
}
