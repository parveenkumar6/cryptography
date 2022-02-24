// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

string encrypt;
string decrypt;
CRYPTOGRAPGY.Encryption.EncryptDecrypt objEncrypt = new CRYPTOGRAPGY.Encryption.EncryptDecrypt();
CRYPTOGRAPGY.Encryption.EncryptDecrypt objDecrypt = new CRYPTOGRAPGY.Encryption.EncryptDecrypt();
objEncrypt.Key = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
objEncrypt.Data = "Parveen";

Console.WriteLine("Data is : " + "Parveen");
encrypt = objEncrypt.encrypt();

Console.WriteLine("Encrypted Data : " + encrypt);
objDecrypt.Key = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
objDecrypt.Data = encrypt;
decrypt = objDecrypt.decrypt();

Console.WriteLine("Decrypted Data : " + decrypt);



