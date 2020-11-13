import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import '../../components/Cabecalho/cabecalho.css'
import '../Meus Favoritos/style.css';

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Home(props){

    const [infos, setInfos] = useState(props.location.state);
    const [anunciosDia, setAnunciosDia] = useState([]);
    const [dia, setDia] = useState();

    const anunciosPorDia = async (dia) => {
        try {
            const resp = await api.anunciosDia(dia);
            setAnunciosDia(resp);
        } catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    const dale = async (xama) => {
        setDia(xama);
        anunciosPorDia(xama);
    }

    return(
        <div className="eiei">
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Relatorio", state: infos}} ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
            </div>
            

            <label className="labelRelatorio">
                Filtrar por data
                <input value={dia} onChange={(e) => dale(e.target.value)} type="date" className="form-control"/>
            </label>
            

            <div class="tabela1">
                <div className="shit1">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Dia</th>
                                <th>Cliente</th>
                                <th>Tipo de Produto</th>
                                <th>Preço</th>
                            </tr>
                        </thead>

                        <tbody>
                            {anunciosDia.map(x =>
                                <tr>
                                    <td>{x.dia.substring(8,10)}/{x.dia.substring(5,7)}/{x.dia.substring(0,4)}</td>
                                    <td>{x.cliente}</td>
                                    <td>{x.tipoProduto}</td>
                                    <td>{x.preco}</td>
                                </tr>
                            )}    
                        </tbody>
                    </table>
                </div>
            </div>
            <ToastContainer/>
            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}