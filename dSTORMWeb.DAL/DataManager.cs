using System;
using dSTORMWeb.DAL.Accessors;

namespace dSTORMWeb.DAL
{
    public class DataManager : IDisposable
    {
        public AOTFilterAccessor AOTFilterAccessor { get; set; }

        public AuthorAccessor AuthorAccessor { get; set; }

        public CameraAccessor CameraAccessor { get; set; }

        public dSTORMInfoAccessor dSTORMInfoAccessor { get; set; }

        public ExperimentAccessor ExperimentAccessor { get; set; }

        public FinalImageAccessor FinalImageAccessor { get; set; }

        public FluorophoreAccessor FluorophoreAccessor { get; set; }

        public FluorophoreResearchObjectAccessor FluorophoreResearchObjectAccessor { get; set; }

        public InitialVideoAccessor InitialVideoAccessor { get; set; }

        public LaserAccessor LaserAccessor { get; set; }

        public MicroscopeAccessor MicroscopeAccessor { get; set; }

        public ObjectiveAccessor ObjectiveAccessor { get; set; }

        public PhysicalPropertiesAccessor PhysicalPropertiesAccessor { get; set; }

        public ResearchObjectAccessor ResearchObjectAccessor { get; set; }

        public SetupAccessor SetupAccessor { get; set; }

        public VideoFragmentAccessor VideoFragmentAccessor { get; set; }


        public DataManager(AOTFilterAccessor aotFA, AuthorAccessor AA, CameraAccessor CA, dSTORMInfoAccessor DSIA, ExperimentAccessor EA,
            FinalImageAccessor FIA, FluorophoreAccessor FA, FluorophoreResearchObjectAccessor FROA, InitialVideoAccessor IVA, LaserAccessor LA,
            MicroscopeAccessor MA, ObjectiveAccessor OA, PhysicalPropertiesAccessor PPA, ResearchObjectAccessor ROA, SetupAccessor SA, VideoFragmentAccessor VFA
            )
        {
            AOTFilterAccessor = aotFA;
            AuthorAccessor = AA;
            CameraAccessor = CA;
            dSTORMInfoAccessor = DSIA;
            ExperimentAccessor = EA;
            FinalImageAccessor = FIA;
            FluorophoreAccessor = FA;
            FluorophoreResearchObjectAccessor = FROA;
            InitialVideoAccessor = IVA;
            LaserAccessor = LA;
            MicroscopeAccessor = MA;
            ObjectiveAccessor = OA;
            PhysicalPropertiesAccessor = PPA;
            ResearchObjectAccessor = ROA;
            SetupAccessor = SA;
            VideoFragmentAccessor = VFA;
        }

        public DataManager(bool init)
        {

        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                 
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
