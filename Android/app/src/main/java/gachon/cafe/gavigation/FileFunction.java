package gachon.cafe.gavigation;

import android.util.Log;

import org.json.JSONObject;

import java.io.File;
import java.io.PrintWriter;
import java.util.Scanner;

public class FileFunction {
    public static void LoginSave(String data) {
        try {
            Log.d("테스트2", "파일 여는중");
            File file = new File("Gachon-Village");
            if( !file.exists() ) {
                file.mkdirs();
            }
            PrintWriter pw = new PrintWriter(ESocketActivity.path.getAbsolutePath() + "iddata.txt");
            pw.write(data + "\r\n");
            pw.flush();
            pw.close();
        } catch (Exception e) {
            Log.d("테스트2", "에러" + e.getMessage());
            e.printStackTrace();
        }
    }

    public static void LoginLoad() {
        try {
            File file = new File(ESocketActivity.path.getAbsolutePath() + "iddata.txt");
            Scanner sc = new Scanner(file);
            String data = sc.nextLine();
            sc.close();
            String[] data2 = data.split(":");
            JSONObject json = new JSONObject();
            json.put("type", 1115);
            json.put("id", data2[0]);
            json.put("password", data2[1]);
            NetworkMain.Send(json);
        }
        catch (Exception e)
        {
            Log.d("테스트2", "2에러" + e.getMessage());
            e.printStackTrace();

        }
    }
    private static void Save(String file, String data)
    {
        try {
            PrintWriter pw = new PrintWriter(ESocketActivity.path.getAbsolutePath() + file);
            pw.write(data + "\r\n");
            pw.flush();
            pw.close();
        } catch (Exception e) {
            Log.d("테스트2", "에러" + e.getMessage());
            e.printStackTrace();
        }
    }
    public static String Load(String file2) {
        try {
            File file = new File(ESocketActivity.path.getAbsolutePath() + file2);
            Scanner sc = new Scanner(file);
            String data = sc.nextLine();
            sc.close();
            return data;
        }
        catch (Exception e)
        {
            Log.d("테스트2", "2에러" + e.getMessage());
            e.printStackTrace();

        }
        return null;
    }
    public static int NextNo()
    {
       String a = Load("a.txt");
       if (a == null)
       {
           Save("a.txt","0");
           return 0;
       }
       else
       {
          int no = Integer.parseInt(a) + 1;
          Save("a.txt",no + "");
          return no;
       }
    }
}
