using System;
using ver1;
namespace Zadanie_2
{
    public class MultifunctionalDevice : BaseDevice, IMultifunctionalDevice
    {
        public int SendCounter { get; private set; } = 0;

        public int ScanCounter { get; private set; } = 0;

        public int PrintCounter { get; private set; } = 0;

        
        public new int Counter { get; private set; } = 0;

        public string DateFormat = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");

        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.off)
                return;
            Console.WriteLine("{0} Print: {1}", DateFormat, document.GetFileName());

            ++PrintCounter;
        }




        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)


        {
            if (GetState() == IDevice.State.off)
            {
                document = null;
                return;
            }
            {
                ++ScanCounter;
            }
            switch (formatType)
            {
                case IDocument.FormatType.JPG:
                    document = new ImageDocument("ImageScan" + ScanCounter + ".jpg");
                    break;

                case IDocument.FormatType.PDF:
                    document = new PDFDocument("ImageScan" + ScanCounter + ".pdf");
                    break;
                case IDocument.FormatType.TXT:
                    document = new TextDocument("ImageScan" + ScanCounter + ".txt");
                    break;
                default:
                    throw new ArgumentException("Undefined file type!");
            }
            Console.WriteLine("{0} Scan: {1}", DateFormat, document.GetFileName());
        }




        public void Send(in IDocument document)
        {
            if (GetState() == IDevice.State.off)
            {
                return;
            }
            Console.WriteLine("{0} Send: {1}", DateFormat, document.GetFileName());
            ++SendCounter;

        }

        public void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                ++Counter;
            }
            base.PowerOn();
        }
    }
}