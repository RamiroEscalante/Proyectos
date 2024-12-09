package com.ramiroyoliver.spotifyblue;

import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Intent;
import android.graphics.BitmapFactory;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.os.Handler;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.SeekBar;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.NotificationCompat;
import androidx.core.app.NotificationManagerCompat;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.ArrayList;
import java.util.Collections;

public class MainActivity extends AppCompatActivity {

    private TextView songTitle;
    private ImageView songImage;
    private ImageButton btnPrev, btnPlayPause, btnNext;
    private Button btnLoop, btnShuffle;
    private SeekBar songSeekBar;

    private MediaPlayer mediaPlayer;
    private Handler handler = new Handler();
    private int currentSongIndex = 0;
    private boolean isPlaying = false;
    private boolean isLooping = false;
    private boolean isShuffling = false;

    private ArrayList<Song> songList; // Lista principal de canciones con imágenes
    private ArrayList<Song> shuffledList;

    private static final String CHANNEL_ID = "music_notification_channel";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        createNotificationChannel(); // Crear canal de notificación

        // Inicialización de los componentes
        songTitle = findViewById(R.id.songTitle);
        songImage = findViewById(R.id.songIamges);
        btnPrev = findViewById(R.id.btnPrev);
        btnPlayPause = findViewById(R.id.btnPlayPause);
        btnNext = findViewById(R.id.btnNext);
        btnLoop = findViewById(R.id.btnLoop);
        btnShuffle = findViewById(R.id.btnShuffle);
        songSeekBar = findViewById(R.id.songSeekBar);

        // Inicializar la lista de canciones con sus imágenes y nombres
        songList = new ArrayList<>();
        songList.add(new Song(R.raw.cansada, R.drawable.piel, "Piel Cansada"));       // Canción 1
        songList.add(new Song(R.raw.frijolero, R.drawable.frijolero, "Frijolero")); // Canción 2
        songList.add(new Song(R.raw.marchar, R.drawable.luismi, "Ahora te puedes marchar"));     // Canción 3
        songList.add(new Song(R.raw.ajenos, R.drawable.ajenos, "Somos ajenos"));      // Canción 4
        songList.add(new Song(R.raw.epico, R.drawable.epico, "Épico"));         // Canción 5

        shuffledList = new ArrayList<>(songList);

        setMediaPlayer(currentSongIndex);

        btnPlayPause.setOnClickListener(v -> {
            if (isPlaying) {
                pauseSong();
            } else {
                playSong();
            }
        });

        btnNext.setOnClickListener(v -> playNextSong());

        btnPrev.setOnClickListener(view -> playPrevSong());

        btnLoop.setOnClickListener(view -> {
            isLooping = !isLooping;
            mediaPlayer.setLooping(isLooping);
            btnLoop.setText(isLooping ? "Bucle activado" : "Bucle continuo");
        });

        btnShuffle.setOnClickListener(view -> {
            isShuffling = !isShuffling;
            if (isShuffling) {
                Collections.shuffle(shuffledList);
                btnShuffle.setText("Aleatorio activado");
            } else {
                shuffledList = new ArrayList<>(songList);
                btnShuffle.setText("Bucle desactivado");
            }

            currentSongIndex = 0;
            setMediaPlayer(currentSongIndex);
        });

        // Configurar la barra de progreso
        songSeekBar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                if (fromUser) {
                    mediaPlayer.seekTo(progress);
                }
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                handler.removeCallbacks(updateSeekBar);
            }

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                handler.post(updateSeekBar);
            }
        });
    }

    private void createNotificationChannel() {
        if (android.os.Build.VERSION.SDK_INT >= android.os.Build.VERSION_CODES.O) {
            CharSequence name = "Music Player Channel";
            String description = "Channel for music player notifications";
            int importance = NotificationManager.IMPORTANCE_LOW;
            NotificationChannel channel = new NotificationChannel(CHANNEL_ID, name, importance);
            channel.setDescription(description);

            NotificationManager notificationManager = getSystemService(NotificationManager.class);
            notificationManager.createNotificationChannel(channel);
        }
    }

    private void showNotification(String songTitle, int songImageResId) {
        Intent intent = new Intent(this, MainActivity.class);
        intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);

        PendingIntent pendingIntent = PendingIntent.getActivity(
                this,
                0,
                intent,
                PendingIntent.FLAG_UPDATE_CURRENT | PendingIntent.FLAG_IMMUTABLE
        );

        NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .setSmallIcon(R.drawable.spot) // Asegúrate de tener un ícono en drawable
                .setContentTitle("Reproduciendo")
                .setContentText(songTitle)
                .setLargeIcon(BitmapFactory.decodeResource(getResources(), songImageResId))
                .setContentIntent(pendingIntent)
                .setPriority(NotificationCompat.PRIORITY_LOW)
                .setAutoCancel(false)
                .setOngoing(true);

        NotificationManagerCompat notificationManager = NotificationManagerCompat.from(this);
        notificationManager.notify(1, builder.build());
    }

    private void setMediaPlayer(int index) {
        if (mediaPlayer != null) {
            mediaPlayer.release();
        }

        // Obtener la canción actual de la lista (normal o aleatoria)
        Song currentSong = shuffledList.get(index);

        // Configurar el MediaPlayer con la canción actual
        mediaPlayer = MediaPlayer.create(this, currentSong.audioResId);

        songTitle.setText(currentSong.name);
        songImage.setImageResource(currentSong.imageResId);
        songSeekBar.setMax(mediaPlayer.getDuration());

        // Mostrar la notificación
        showNotification(currentSong.name, currentSong.imageResId);

        mediaPlayer.setOnCompletionListener(mp -> playNextSong());
    }

    private void playSong() {
        mediaPlayer.start();
        isPlaying = true;
        btnPlayPause.setImageResource(android.R.drawable.ic_media_pause);
        handler.post(updateSeekBar); // Iniciar la actualización de la barra de progreso
    }

    private void pauseSong() {
        mediaPlayer.pause();
        isPlaying = false;
        btnPlayPause.setImageResource(android.R.drawable.ic_media_play);
        handler.removeCallbacks(updateSeekBar);

        // Cancelar la notificación
        NotificationManagerCompat.from(this).cancel(1);
    }

    private void playNextSong() {
        currentSongIndex = (currentSongIndex + 1) % shuffledList.size();
        setMediaPlayer(currentSongIndex);
        playSong();
    }

    private void playPrevSong() {
        currentSongIndex = (currentSongIndex - 1 + shuffledList.size()) % shuffledList.size();
        setMediaPlayer(currentSongIndex);
        playSong();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        if (mediaPlayer != null) {
            mediaPlayer.release();
        }
        handler.removeCallbacks(updateSeekBar); // Limpiar los callbacks
    }

    // Runnable para actualizar la barra de progreso
    private Runnable updateSeekBar = new Runnable() {
        @Override
        public void run() {
            if (mediaPlayer != null) {
                songSeekBar.setProgress(mediaPlayer.getCurrentPosition());
                handler.postDelayed(this, 1000); // Actualizar cada segundo
            }
        }
    };

    // Clase Song para relacionar canciones con imágenes y nombres
    private static class Song {
        int audioResId;
        int imageResId;
        String name;

        Song(int audioResId, int imageResId, String name) {
            this.audioResId = audioResId;
            this.imageResId = imageResId;
            this.name = name;
        }
    }
}
