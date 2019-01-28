using ExternalQuizSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExternalQuizSite.Controllers {
    public class QuizController : ApiController {

        /**************************************************     GET
         *************************************************/

        // GET api/quiz
        public Quiz Get() {
            GetQuiz get = new GetQuiz();
            return get.DefaultQuiz();
        }




        // GET api/quiz/5
        public Quiz Get(int id) {
            
            Quiz quiz = new Quiz();
            GetQuiz get = new GetQuiz();
            if (id >= 0 && id < 10) {
                quiz = get.DefaultQuiz(" Quiz " + id);
            }
            else {
                quiz = null;
            }
            return quiz;
        }





        // GET api/quiz/{API}
        public void GET([FromBody]API api) {
            ExternalConnection externalConnection = new ExternalConnection();
            externalConnection.SaveQuiz(api);
        }



        /**************************************************     POST
         *************************************************/
        // POST api/quiz
        public void Post([FromBody]string value) {

        }





        /**************************************************     PUT
         *************************************************/
        // PUT api/quiz/5
        public void Put(int id, [FromBody]string value) {

        }






        /**************************************************     DELETE
         *************************************************/
        // DELETE api/quiz/5
        public void Delete(int id) {

        }


    }
}
