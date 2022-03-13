using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WorkBook3.Domain.Entities;
using WorkBook3.Domain.Helpers;

namespace WorkBook3.WPF.ViewModels
{
    public class FixDataCreateViewModel : BindableBase, IDialogAware
    {
        StringBuilder buff = new StringBuilder();
        public FixDataCreateViewModel()
        {
            _fixDataList = new ObservableCollection<FixDataEntity>
            {
                new FixDataEntity("発注日", 3),
                new FixDataEntity("発注番号",10),
                 new FixDataEntity("備考",5),
                                 new FixDataEntity("発注日", 30),
                new FixDataEntity("発注番号",200),
                 new FixDataEntity("備考",5),
            };

            CreateData = new DelegateCommand(
                ()=>{
                    foreach(var data in FixDataList)
                    {
                        data.Create(_fixChar);
                    }
                    FixDataList = FixDataList;
            }
                );

            CreateFile = new DelegateCommand(
                () =>
                {
                    buff.Clear();
                    foreach (var data in FixDataList)
                    {
                        buff.Append(data.CreateData);
                    }
                    FileData = buff.ToString();
                });

            CreateColumn = new DelegateCommand(
                () =>
                {
                    List<string> columnList = StringHelper.GetList(ColumnData);
                    FixDataList.Clear();
                    foreach(var column in columnList)
                    {
                        FixDataList.Add(new FixDataEntity(column));
                    }

                });

            NoClear = new DelegateCommand(() =>
            {
                FixDataEntity._no = 1;
            });
        }

        public string Title => "固定長作成";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {

            return true;
        }

        public void OnDialogClosed()
        {
          
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        ObservableCollection<FixDataEntity> _fixDataList;
        public ObservableCollection<FixDataEntity> FixDataList
        {
            get { return _fixDataList; }
            set
            {
                SetProperty(ref _fixDataList, value);

            }
        }

        /// <summary>
        /// データ作成ボタンクリック.
        /// </summary>
        public DelegateCommand CreateData { get; }

        /// <summary>
        /// 列情報作成ボタンクリック.
        /// </summary>
        public DelegateCommand CreateColumn { get; }

        /// <summary>
        /// ファイル作成ボタンクリック.
        /// </summary>
        public DelegateCommand CreateFile { get; }

        public DelegateCommand NoClear { get; }
        

        private string _fixChar = "1";
        /// <summary>
        /// 固定文字.
        /// </summary>
        public string FixChar
        {
            get { return _fixChar; }
            set { SetProperty(ref _fixChar, value); }
        }

        private string _fileData;
        /// <summary>
        /// 固定文字.
        /// </summary>
        public string FileData
        {
            get { return _fileData; }
            set { SetProperty(ref _fileData, value); }
        }


        private string _columnData;
        /// <summary>
        /// 固定文字.
        /// </summary>
        public string ColumnData
        {
            get { return _columnData; }
            set { SetProperty(ref _columnData, value); }
        }
    }
}
