import * as sql from 'mssql';
import dotenv from 'dotenv';

const config: sql.config = {
  user: process.env.DB_USER || '',
  password: process.env.DB_PASSWORD || '',
  server: process.env.DB_SERVER || '',
  database: process.env.DB_NAME || '',
};

const pool = new sql.ConnectionPool(config);
const db = async () => {
  if (!pool.connected) {
    await pool.connect();
  }
  return pool;
};

export default db;