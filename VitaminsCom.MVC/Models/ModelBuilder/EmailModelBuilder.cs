using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Data;
using VitaminsCom.MVC.Infrastructure.Exceptions;

namespace VitaminsCom.MVC.Models
{

    public interface IEmailModelBuilder
    {
        EmailModel SaveEmail(EmailModel model);
    }

    public class EmailModelBuilder : IEmailModelBuilder
    {

        readonly dynamic _db;
        readonly dynamic _db1;
        readonly dynamic _db2;
        public EmailModelBuilder()
        {
            _db = Database.OpenNamedConnection("VitaminsDb");
            _db1 = Database.OpenNamedConnection("Shop_Cartdb");
            _db2 = Database.OpenNamedConnection("WebStoreDB");
            
        }

        public EmailModel SaveEmail(EmailModel model)
        {
            EmailModel emailopt = _db.EmailGroup.UpsertByEmail(Email: model.Email, AcqSource: model.AcqSource, Acqsubsource: model.Acqsubsource,DivisionName:model.DivisionName,Language:model.Language, DateModified: DateTime.Now, OptinOut: true);

            emailopt = _db.EmailGroup.FindByEmail(Email: model.Email,AcqSource:model.AcqSource,Acqsubsource:model.Acqsubsource,DivisionName:model.DivisionName,Language:model.Language, DateModified: DateTime.Now, OptinOut: true);
            // var result = _db1.emails.UpsertByEmailAndwsid(Email: email, wsid: 56, OptInFlag: true);

            //if (emailopt == null)
            //{
            //    emailopt = _db.EmailGroup.UpsertByEmail(Email: model.Email, AcqSource: model.AcqSource, Acqsubsource: model.Acqsubsource, DateModified: DateTime.Now, OptinOut: true);
               
            //}
            if (emailopt != null)
            {
                var result = _db2.CreateEmailSignupMessage(Company: model.DivisionName, MessageId: System.Guid.NewGuid().ToString(),MailRecipient: emailopt.Email, AcqSource: emailopt.AcqSource, AcqSubSource: emailopt.Acqsubsource, DivisionName: "vitamins", LanguageISO3: model.Language, FirstName: "", LastName: "");

            }
            return emailopt;
        }

       
    }


}