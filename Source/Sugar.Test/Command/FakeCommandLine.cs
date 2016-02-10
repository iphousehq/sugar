using System.Collections.Generic;

namespace Sugar.Command
{
    internal class FakeCommandLine : CommandLine
    {
        public IEnumerable<int> CurrentProcessIds { get; set; }

        public int CurrentProcessId { get; set; }

        public FakeCommandLine(int currentProcessId, IEnumerable<int> currentProcessIds)
        {
            CurrentProcessId = currentProcessId;
            CurrentProcessIds = currentProcessIds;
        }

        public override int GetCurrentProcessId()
        {
            return CurrentProcessId;
        }

        public override IList<int> GetProcessIds(string filename)
        {
            return new List<int>(CurrentProcessIds);
        }

        public override string GetCommandLine(int processId)
        {
            return "-arg " + processId;
        }
    }
}