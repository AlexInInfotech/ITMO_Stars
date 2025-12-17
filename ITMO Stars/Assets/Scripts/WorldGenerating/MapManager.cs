using System.Diagnostics;
using System;
using System.Drawing;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public const byte MainMapSize = 2;
    public const byte BiomMapSize = 4;
    [Header("Main Settings")]
    [SerializeField] float main_scale;
    [SerializeField] int main_octaves;
    [SerializeField] float main_persistence;
    [SerializeField] float main_lacunarity;
    [SerializeField] int main_seed;

    [Header("River Settings")]
    [SerializeField] float river_scale;
    [SerializeField] int river_octaves;
    [SerializeField] float river_persistence;
    [SerializeField] float river_lacunarity;
    [SerializeField] int river_seed;

    [Header("Biom Settings")]
    [SerializeField] float biom_scale;
    [SerializeField] int biom_octaves;
    [SerializeField] float biom_persistence;
    [SerializeField] float biom_lacunarity;
    [SerializeField] int biom_seed;
}