
using System;
using System.Collections.Generic;

// Class Orang sebagai class induk
class Orang
{
    public string Nama { get; set; }
    public int Umur { get; set; }

    public Orang(string nama, int umur)
    {
        Nama = nama;
        Umur = umur;
    }

    public virtual void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang melakukan aktivitas.");
    }

    public void InfoOrang()
    {
        Console.WriteLine("Nama: " + Nama);
        Console.WriteLine("Umur: " + Umur + " tahun");
    }
}

// Class Pasien mewarisi Orang
class Pasien : Orang
{
    public string Keluhan { get; set; }

    public Pasien(string nama, int umur, string keluhan)
        : base(nama, umur)
    {
        Keluhan = keluhan;
    }

    public void CekKeluhan()
    {
        Console.WriteLine("Keluhan: " + Keluhan);
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang menjalani pemeriksaan.");
    }
}

// Class TenagaMedis mewarisi Orang
class TenagaMedis : Orang
{
    public string Spesialisasi { get; set; }

    public TenagaMedis(string nama, int umur, string spesialisasi)
        : base(nama, umur)
    {
        Spesialisasi = spesialisasi;
    }

    public void CekSpesialis()
    {
        Console.WriteLine("Spesialisasi: " + Spesialisasi);
    }

    public override void Aktivitas()
    {
        Console.WriteLine(Nama + " sedang bertugas sebagai tenaga medis.");
    }
}

// Class Dokter mewarisi TenagaMedis
class Dokter : TenagaMedis
{
    public Dokter(string nama, int umur, string spesialisasi)
        : base(nama, umur, spesialisasi)
    {
    }

    public void Diagnosa()
    {
        Console.WriteLine("Dokter " + Nama + " sedang mendiagnosis pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Dokter " + Nama + " sedang memeriksa pasien.");
    }
}

// Class Perawat mewarisi TenagaMedis
class Perawat : TenagaMedis
{
    public Perawat(string nama, int umur, string spesialisasi)
        : base(nama, umur, spesialisasi)
    {
    }

    public void CekPasien()
    {
        Console.WriteLine("Perawat " + Nama + " sedang mengecek kondisi pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Perawat " + Nama + " sedang merawat pasien.");
    }
}

// Class PasienAnak mewarisi Pasien
class PasienAnak : Pasien
{
    public PasienAnak(string nama, int umur, string keluhan)
        : base(nama, umur, keluhan)
    {
    }

    public void Menangis()
    {
        Console.WriteLine(Nama + " sedang menangis karena takut diperiksa.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Pasien anak " + Nama + " sedang diperiksa.");
    }
}

// Class PasienDewasa mewarisi Pasien
class PasienDewasa : Pasien
{
    public PasienDewasa(string nama, int umur, string keluhan)
        : base(nama, umur, keluhan)
    {
    }

    public void Konsultasi()
    {
        Console.WriteLine(Nama + " sedang berkonsultasi dengan dokter.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine("Pasien dewasa " + Nama + " sedang menjalani konsultasi.");
    }
}

// Class RumahSakit untuk menyimpan kumpulan Orang
class RumahSakit
{
    private List<Orang> daftarOrang = new List<Orang>();

    public void TambahOrang(Orang orang)
    {
        daftarOrang.Add(orang);
        Console.WriteLine(orang.Nama + " berhasil ditambahkan.");
    }

    public void DaftarOrang()
    {
        Console.WriteLine("\n=== DAFTAR ORANG DI RUMAH SAKIT ===");

        foreach (Orang orang in daftarOrang)
        {
            orang.InfoOrang();
            orang.Aktivitas();

            Console.WriteLine("------------------------------");
        }
    }
}

// Class utama program
class Program
{
    static void Main(string[] args)
    {
        // Membuat objek rumah sakit
        RumahSakit rs = new RumahSakit();

        // Membuat objek orang
        Dokter dokter = new Dokter("Dias", 35, "Penyakit Dalam");
        Perawat perawat = new Perawat("Rara", 28, "Keperawatan Umum");
        Pasien pasien = new Pasien("Abiyyu", 25, "Demam");
        PasienAnak anak = new PasienAnak("Kelly", 7, "Batuk");
        PasienDewasa dewasa = new PasienDewasa("Andro", 40, "Sakit Kepala");

        // Menambahkan objek ke rumah sakit
        rs.TambahOrang(dokter);
        rs.TambahOrang(perawat);
        rs.TambahOrang(pasien);
        rs.TambahOrang(anak);
        rs.TambahOrang(dewasa);

        // Menampilkan seluruh data
        rs.DaftarOrang();

        // Demonstrasi polymorphism
        Console.WriteLine("\n=== DEMONSTRASI POLYMORPHISM ===");

        Orang orang1 = dokter;
        Orang orang2 = pasien;
        Orang orang3 = perawat;

        orang1.Aktivitas();
        orang2.Aktivitas();
        orang3.Aktivitas();

        // Menampilkan informasi dokter
        Console.WriteLine("\n=== INFORMASI DOKTER ===");
        dokter.InfoOrang();
        dokter.CekSpesialis();

        // Memanggil method khusus
        Console.WriteLine("\n=== METHOD KHUSUS ===");

        dokter.Diagnosa();
        perawat.CekPasien();
        pasien.CekKeluhan();
        anak.Menangis();
        dewasa.Konsultasi();

        Console.WriteLine("\nProgram selesai.");
        Console.ReadKey();
    }
}
