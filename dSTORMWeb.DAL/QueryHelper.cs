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
                    case FilterNames.FIRSTNAME:
                        q = q.Where(e => e.FirstName.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MIDDLENAME:
                        q = q.Where(e => e.MiddleName.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.LASTNAME:
                        q = q.Where(e => e.LastName.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.ACADEMICRANK:
                        q = q.Where(e => e.AcademicRank.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.FIRSTNAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.FirstName) : q.OrderByDescending(e => e.FirstName);
                    break;
                case FilterNames.MIDDLENAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.MiddleName) : q.OrderByDescending(e => e.MiddleName);
                    break;
                case FilterNames.LASTNAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.LastName) : q.OrderByDescending(e => e.LastName);
                    break;
                case FilterNames.ACADEMICRANK:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.AcademicRank) : q.OrderByDescending(e => e.AcademicRank);
                    break;
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
                    case FilterNames.NAME:
                        q = q.Where(e => e.Name.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.INTENSITYVALUE:
                        q = q.Where(e => e.IntensityValue.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
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
                case FilterNames.INTENSITYVALUE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.IntensityValue) : q.OrderByDescending(e => e.IntensityValue);
                    break;
                case FilterNames.DESCRIPTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description);
                    break;
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
                    case FilterNames.PRODUCER:
                        q = q.Where(e => e.Producer.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MODEL:
                        q = q.Where(e => e.Model.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.OBJECRTIVE:
                        q = q.Where(e => e.Objective.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.FOCALLENGTH:
                        q = q.Where(e => e.FocalLength.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MATRIXTYPE:
                        q = q.Where(e => e.MatrixType.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.DESCRIPTION:
                        q = q.Where(e => e.Description.ToLower().Contains((f.Value.Value[0]).ToLower()));
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
                case FilterNames.OBJECRTIVE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Objective) : q.OrderByDescending(e => e.Objective);
                    break;
                case FilterNames.FOCALLENGTH:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.FocalLength) : q.OrderByDescending(e => e.FocalLength);
                    break;
                case FilterNames.MATRIXTYPE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.MatrixType) : q.OrderByDescending(e => e.MatrixType);
                    break;
                case FilterNames.DESCRIPTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description);
                    break;
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
                    case FilterNames.XCOORD:
                        q = q.Where(e => e.XCoord.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.YCOORD:
                        q = q.Where(e => e.YCoord.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case "VideoFragmentId":
                        q = q.Where(e => e.VideoFragmentId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.XCOORD:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.XCoord) : q.OrderByDescending(e => e.XCoord);
                    break;
                case FilterNames.YCOORD:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.YCoord) : q.OrderByDescending(e => e.YCoord);
                    break;
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
                    case FilterNames.INITIALVIDEONAME:
                        q = q.Where(e => e.InitialVideoId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                    case FilterNames.FORMAT:
                        q = q.Where(e => e.Format.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.RESOLUTION:
                        q = q.Where(e => e.Resolution.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.INITIALVIDEONAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.InitialVideoId) : q.OrderByDescending(e => e.InitialVideoId);
                    break;
                case FilterNames.FORMAT:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Format) : q.OrderByDescending(e => e.Format);
                    break;
                case FilterNames.RESOLUTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Resolution) : q.OrderByDescending(e => e.Resolution);
                    break;
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
                    case FilterNames.NAME:
                        q = q.Where(e => e.Name.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.FORMAT:
                        q = q.Where(e => e.Format.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.RESOLUTION:
                        q = q.Where(e => e.Resolution.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.FRAMEFREQUENCY:
                        q = q.Where(e => e.FrameFrequency.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.SIZE:
                        q = q.Where(e => e.Size.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.DURATION:
                        q = q.Where(e => e.Duration.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
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
                case FilterNames.FORMAT:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Format) : q.OrderByDescending(e => e.Format);
                    break;
                case FilterNames.RESOLUTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Resolution) : q.OrderByDescending(e => e.Resolution);
                    break;
                case FilterNames.FRAMEFREQUENCY:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.FrameFrequency) : q.OrderByDescending(e => e.FrameFrequency);
                    break;
                case FilterNames.SIZE:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Size) : q.OrderByDescending(e => e.Size);
                    break;
                case FilterNames.DURATION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Duration) : q.OrderByDescending(e => e.Duration);
                    break;
                case FilterNames.DESCRIPTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description);
                    break;
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
                    case FilterNames.PRODUCER:
                        q = q.Where(e => e.Producer.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MODEL:
                        q = q.Where(e => e.Model.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.TYPE:
                        q = q.Where(e => e.Type.ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.WAVELENGTH:
                        q = q.Where(e => e.WaveLength.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.MAXPOWER:
                        q = q.Where(e => e.MaxPower.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.OUTPUTPOWER:
                        q = q.Where(e => e.OutputPower.ToString().ToLower().Contains((f.Value.Value[0]).ToLower()));
                        break;
                    case FilterNames.DESCRIPTION:
                        q = q.Where(e => e.Description.ToLower().Contains((f.Value.Value[0]).ToLower()));
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
                case FilterNames.MAXPOWER:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.MaxPower) : q.OrderByDescending(e => e.MaxPower);
                    break;
                case FilterNames.WAVELENGTH:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.WaveLength) : q.OrderByDescending(e => e.WaveLength);
                    break;
                case FilterNames.OUTPUTPOWER:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.OutputPower) : q.OrderByDescending(e => e.OutputPower);
                    break;
                case FilterNames.DESCRIPTION:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Description) : q.OrderByDescending(e => e.Description);
                    break;
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
                    case FilterNames.AOTFILTERNAME:
                        q = q.Where(e => e.AOTFilterId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                    case FilterNames.CAMERANAME:
                        q = q.Where(e => e.CameraId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                    case FilterNames.MICROSCOPENAME:
                        q = q.Where(e => e.MicroscopeId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                    case FilterNames.LASERNAME:
                        q = q.Where(e => e.LaserId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                    case FilterNames.OBJECTIVENAME:
                        q = q.Where(e => e.ObjectiveId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.AOTFILTERNAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.AOTFilter.Name) : q.OrderByDescending(e => e.AOTFilter.Name);
                    break;
                case FilterNames.CAMERANAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Camera.Producer) : q.OrderByDescending(e => e.Camera.Producer);
                    break;
                case FilterNames.MICROSCOPENAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Microscope.Producer) : q.OrderByDescending(e => e.Microscope.Producer);
                    break;
                case FilterNames.LASERNAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Laser.Producer) : q.OrderByDescending(e => e.Laser.Producer);
                    break;
                case FilterNames.OBJECTIVENAME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.Objective.Name) : q.OrderByDescending(e => e.Objective.Name);
                    break;
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
                    case "InitialVideoId":
                        q = q.Where(e => e.InitialVideoId == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                    case FilterNames.FRAMETIME:
                        q = q.Where(e => e.FrameTime == System.Convert.ToInt32(f.Value.Value[0]));
                        break;
                }
            }
            string sortOrder = sortfield.Contains(' ') == true ? sortfield.Split(new char[] { ' ' })[1] : "asc";
            switch (sortfield.Split(new char[] { ' ' })[0].ToLower())
            {
                case FilterNames.FRAMETIME:
                    q = (sortOrder == "asc") ? q.OrderBy(e => e.FrameTime) : q.OrderByDescending(e => e.FrameTime);
                    break;
            }
            return q;
        }
    }
}