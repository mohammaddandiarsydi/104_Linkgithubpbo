using System;

namespace Inheritancee
{
    public class KomisiKaryawan : object
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomorKTP { get; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        public KomisiKaryawan(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
        }

        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{ nameof(PenjualanKotor)} harus >= 0");
                }
                penjualanKotor = value;
            }
        }

        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
                }
                tingkatKomisi = value;
            }
        }

        public decimal Pendapatan() => tingkatKomisi * penjualanKotor;

        public override string ToString() =>
            $" Komisi Karyawan: {NamaDepan} {NamaBelakang}\n" +
            $" Nomor KTP: {NomorKTP}\n" +
            $" Penjualan Kotor: {penjualanKotor:C}\n" +
            $" Tingkat Komisi: {tingkatKomisi:F2}";
    }
    class TesKomisiKaryawan
    {
        static void Main()
        {
            var karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

            Console.WriteLine(" Informasi karyawan diperoleh dengan properti dan metode: \n");
            Console.WriteLine($" Nama depan: {karyawan.NamaDepan}");
            Console.WriteLine($" Nama belakang: {karyawan.NamaBelakang}");
            Console.WriteLine($" Nomor KTP: {karyawan.NomorKTP}");
            Console.WriteLine($" Penjualan Kotor: {karyawan.PenjualanKotor:C}");
            Console.WriteLine($" Tingkat komisi: {karyawan.TingkatKomisi:F2}");
            Console.WriteLine($" Pendapatan: {karyawan.Pendapatan():C}");

            karyawan.PenjualanKotor = 5000.00M;
            karyawan.TingkatKomisi = .1M;

            Console.WriteLine("\n Perbarui informasi karyawan yang diperoleh dari ToString: \n");
            Console.WriteLine(karyawan);
            Console.WriteLine($" Pendapatan: {karyawan.Pendapatan():C}");
        }
    }
}