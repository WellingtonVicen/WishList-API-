using System.Collections.Generic;
using Domain.Validators;
using Core.Execptions;

namespace Domain.Entities
{
    public class Item : Base
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public string PhotoUrl { get; private set; }
        public bool WonOrBought { get; private set; }

        //EF

        protected Item() { }

        public Item(string title, string description, string link, string photoUrl, bool wonOrBought)
        {
            Title = title;
            Description = description;
            Link = link;
            PhotoUrl = photoUrl;
            WonOrBought = wonOrBought;
            _errors = new List<string>();

            Validate();

        }

        public void ChangeTitle(string title)
        {
            Title = title;
            Validate();
        }
        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }
        public void ChangeLink(string link)
        {
            Link = link;
            Validate();
        }
        public void ChangePhotoUrl(string url)
        {
            PhotoUrl = url;
            Validate();
        }
        public void ChangeWonOrBought(bool wonOrBought)
        {
            WonOrBought = wonOrBought;

        }

        public override bool Validate()
        {
            var validator = new ItemValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainExecptions("Alguns campos estão invalidos por favor corrija-os ", _errors);
            }

            return true;
        }
    }
}