using WorkBook3.Domain.Helpers;

namespace WorkBook3.Domain.Entities
{
    public class FixDataEntity
    {
        public static int _no = 1;
        public FixDataEntity(string name, int length)
        {
            No = _no++;
            Name = name;
            Length = length;

        }

        public FixDataEntity(string data)
        {
            if(data == null)
            {
                return;
            }
            var datas = data.Split(',');
            if(datas.Length < 2)
            {
                return;
            }
            No = _no++;
            Name = datas[0];
            int defaultLength = 0;
            int.TryParse(datas[1], out defaultLength);
            Length = defaultLength;
        }

        public int No { get; }

        public string Name { get; }

        public int Length { get; }

        public string CreateData { get; set; }

        public void Create(string fix)
        {
            CreateData = PaddingHelper.GetData(fix, No, Length);
        }

    }


}
