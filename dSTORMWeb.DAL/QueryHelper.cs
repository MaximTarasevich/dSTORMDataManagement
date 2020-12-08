using System;
using System.Collections.Generic;
using System.Linq;
using dSTORMWeb.DAL.Models;
using dSTORMWeb.Shared;
using dSTORMWeb.Shared.Models;

namespace dSTORMWeb.DAL
{
    public class QueryHelper
    {
        public static IQueryable<Author> BuildQuery(IQueryable<Author> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<AOTFilter> BuildQuery(IQueryable<AOTFilter> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<Camera> BuildQuery(IQueryable<Camera> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<dSTORMInfo> BuildQuery(IQueryable<dSTORMInfo> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<Experiment> BuildQuery(IQueryable<Experiment> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<FinalImage> BuildQuery(IQueryable<FinalImage> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<Fluorophore> BuildQuery(IQueryable<Fluorophore> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<ResearchObject> BuildQuery(IQueryable<ResearchObject> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<FluorophoreResearchObject> BuildQuery(IQueryable<FluorophoreResearchObject> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<InitialVideo> BuildQuery(IQueryable<InitialVideo> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<Laser> BuildQuery(IQueryable<Laser> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<Microscope> BuildQuery(IQueryable<Microscope> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {
                    case FilterNames.PRODUCER:
                        q = q.Where(e => e.Producer.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MODEL:
                        q = q.Where(e => e.Model.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.TYPE:
                        q = q.Where(e => e.Type.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.PRODUCER:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Producer) : q.OrderByDescending(e => e.Producer);
                    break;
                case FilterNames.MODEL:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Model) : q.OrderByDescending(e => e.Model);
                    break;
                case FilterNames.TYPE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Type) : q.OrderByDescending(e => e.Type);
                    break;
            }
            return q;
        }

        public static IQueryable<Objective> BuildQuery(IQueryable<Objective> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {
                    case FilterNames.NAME:
                        q = q.Where(e => e.Name.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MAGNIFICATION:
                        q = q.Where(e => e.Magnification.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.RESOLUTION:
                        q = q.Where(e => e.Resolution.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.EYEPIECE:
                        q = q.Where(e => e.EyePiece.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.OBJECTIVELENS:
                        q = q.Where(e => e.ObjectiveLens.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.DESCRIPTION:
                        q = q.Where(e => e.Description.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.NAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Name) : q.OrderByDescending(e => e.Name);
                    break;
                case FilterNames.MAGNIFICATION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Magnification) : q.OrderByDescending(e => e.Magnification);
                    break;
                case FilterNames.RESOLUTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Resolution) : q.OrderByDescending(e => e.Resolution);
                    break;
                case FilterNames.EYEPIECE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.EyePiece) : q.OrderByDescending(e => e.EyePiece);
                    break;
                case FilterNames.OBJECTIVELENS:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.ObjectiveLens) : q.OrderByDescending(e => e.ObjectiveLens);
                    break;
                case FilterNames.DESCRIPTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description);
                    break;
            }
            return q;
        }
        public static IQueryable<PhysicalProperty> BuildQuery(IQueryable<PhysicalProperty> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {
                    case FilterNames.TEMPERATURE:
                        q = q.Where(e => e.Temperature.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.HUMIDITY:
                        q = q.Where(e => e.Humidity.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.HUMIDITY:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Humidity) : q.OrderByDescending(e => e.Humidity);
                    break;
                case FilterNames.TEMPERATURE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Temperature) : q.OrderByDescending(e => e.Temperature);
                    break;
            }
            return q;
        }
        public static IQueryable<Setup> BuildQuery(IQueryable<Setup> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
        public static IQueryable<VideoFragment> BuildQuery(IQueryable<VideoFragment> q, Dictionary<string, FilterEntity> filters, string sortfield = "")
        {
            foreach (var f in filters)
            {
                var fKey = f.Key;

                switch (fKey)
                {

                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {

            }
            return q;
        }
    }
}