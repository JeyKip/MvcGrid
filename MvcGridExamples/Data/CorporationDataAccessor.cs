using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcGridExamples.Models;

namespace MvcGridExamples.Data
{
    public static class CorporationDataAccessor
    {
        private static List<Corporation> corporations = new List<Corporation>() 
        {
            new Corporation()
            {
                Id = 1,
                Name = "Apple",
                Description = "Apple Inc. — американская корпорация, производитель персональных и планшетных компьютеров, аудиоплееров, телефонов, программного обеспечения.",
                LogoUrl = "/Content/images/logos/apple.jpg",
                Creators = new List<Creator>()
                {
                    new Creator()
                    {
                        Id = 1,
                        Name = "Стив Джобс",
                        ShortBiography = "Стив Джобс — американский предприниматель, получивший широкое признание в качестве пионера эры IT-технологий. Один из основателей, председатель совета директоров и CEO корпорации Apple. Один из основателей и CEO киностудии Pixar.",
                        PhotoUrl = "/Content/images/photo/steve_jobs.jpg"
                    },
                    new Creator()
                    {
                        Id = 2,
                        Name = "Стив Возник",
                        ShortBiography = "Сти́вен Гэ́ри «Воз» Во́зняк — американский разработчик компьютеров и бизнесмен, соучредитель компании Apple.",
                        PhotoUrl = "/Content/images/photo/steve_voznyak.jpg"
                    }
                }
            },
            new Corporation()
            {
                Id = 2,
                Name = "Microsoft",
                Description = "Microsoft Corporation — одна из крупнейших транснациональных компаний по производству проприетарного программного обеспечения для различного рода вычислительной техники — персональных компьютеров, игровых приставок, КПК, мобильных телефонов и прочего, разработчик наиболее широко распространённой на данный момент в мире программной платформы — семейства операционных систем Windows.",
                LogoUrl = "/Content/images/logos/microsoft.jpg",
                Creators = new List<Creator>()
                {
                    new Creator()
                    {
                        Id = 3,
                        Name = "Билл Гейтс",
                        ShortBiography = "Уи́льям Ге́нри Гейтс III , более известный как Билл Гейтс — американский предприниматель и общественный деятель, филантроп, один из создателей (совместно с Полом Алленом) и крупнейший акционер компании Microsoft. До июня 2008 года являлся руководителем компании, после ухода с поста остался в должности её неисполнительного председателя совета директоров. Также является сопредседателем благотворительного Фонда Билла и Мелинды Гейтс.",
                        PhotoUrl = "/Content/images/photo/bill_geits.jpg"
                    },
                    new Creator()
                    {
                        Id = 4,
                        Name = "Пол Аллен",
                        ShortBiography = "Пол Гарднер Аллен — американский предприниматель, соучредитель Корпорации Майкрософт, которую он вместе со своим школьным приятелем Биллом Гейтсом основал в 1975 году. В 2011 году Аллен занимал 57 место в списке журнала Forbes с капиталом в $13 млрд.",
                        PhotoUrl = "/Content/images/photo/pol_allen.jpg"
                    },
                    new Creator()
                    {
                        Id = 5,
                        Name = "Стив Балмер",
                        ShortBiography = "Стивен Энтони Балмер — генеральный директор Корпорации Майкрософт с января 2008 года по февраль 2014. В 2013 году он, будучи наёмным работником, обладал состоянием в $15,2 млрд, что по данным журнала Forbes соответствует 51 месту в списке богатейших людей планеты, и первому в списке богатейших людей не являющихся собственниками бизнеса или их родственниками. Балмер стал первым миллиардером в мире, обязанным своим состоянием опционам, полученным от своего работодателя — корпорации Microsoft, в которой он не был ни основателем, ни родственником основателя.",
                        PhotoUrl = "/Content/images/photo/steve_balmer.jpg"
                    }
                }
            }
        };

        public static List<Corporation> GetCorporations()
        {
            return corporations;
        }
    }
}