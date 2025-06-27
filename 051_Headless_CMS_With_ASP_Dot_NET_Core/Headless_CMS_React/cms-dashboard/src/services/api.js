import axios from 'axios';

const API_BASE = 'https://localhost:5001/api';

export const getContentByType = (type) =>
  axios.get(`${API_BASE}/content/${type}`);

export const createContent = (data) =>
  axios.post(`${API_BASE}/content`, data);

export const uploadMedia = (file) => {
  const formData = new FormData();
  formData.append("file", file);
  return axios.post(`${API_BASE}/media/upload`, formData);
};
